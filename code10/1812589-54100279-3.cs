    using System.Collections.Generic;
    using dbzBest.Models;
    using Microsoft.AspNetCore.Mvc;
    
    namespace zpmAPI.Controllers
    {
        [Route("api/[controller]/[action]")]
        [ApiController]
        [Consumes("application/json")]
        public class PropertyController : ControllerBase
        {
            [HttpPost]
            public List<PropertyTile> Search(PropertySearch s)
            {
                try
                {
                    List<PropertyTile> tiles = new List<PropertyTile>();
                    dbzBest.Data.Properties db = new dbzBest.Data.Properties();
                    tiles = db.Search(s);
                    return tiles;
                }
                catch (System.Exception ex)
                {
                    PropertyTile e = new PropertyTile();
                    e.Description = ex.Message;
                    List<PropertyTile> error = new List<PropertyTile>();
                    error.Add(e);
                    return error;
                }
            }
        }
    }
    
