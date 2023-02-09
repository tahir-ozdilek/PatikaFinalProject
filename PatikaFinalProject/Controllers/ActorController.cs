using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PatikaFinalProject.Common;
using PatikaFinalProject.DataAccess;
using PatikaFinalProject.Services;
using System.Data;

namespace PatikaFinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        ActorService _actorService;

        private readonly ILogger<ActorService> _logger;

        public ActorController(ILogger<ActorService> logger, ActorService service)
        {
            _actorService = service;
            _logger = logger;
        }

        [HttpPost(Name = "AddActor")]
        public async Task<IResponse<ActorCreateDTO>> AddActor(ActorCreateDTO newActor)
        {
            return await _actorService.Create(newActor);
        }
        
        [HttpGet(Name = "DeleteActor")]
        public async Task<IResponse> DeleteActor(int id)
        {
            return await _actorService.Remove(id);
        }

        [HttpPut(Name = "UpdateActor")]
        public async Task<IResponse<ActorCreateDTO>> UpdateActor(ActorDTO newActor)
        {
            return await _actorService.Update(newActor);
        }

        [HttpGet(Name = "DeleteActor")]
        public async Task<IResponse> GetActors( )
        {
            return await _actorService.GetAll();
        }
    }
}