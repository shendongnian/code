    namespace MyGamesProject.Controllers
     {
        public class GamesController : ApiController
        {
             public IHttpActionResult Get(long id)
             {
                var games = db.Games.Include(d => d.DailyDatas)
                             .GroupBy(d => new { d.name, d.year })
                             .OrderBy(d => d.Key.name)
                             .Select(d => new
                             {
                              d.Key.year,
                              d.Key.name
                             }).ToList();
        
             return Ok(games);
          }    
         }
        }
