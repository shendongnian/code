    namespace Music.Controllers.API
     {
        public class AlbumsController : ApiController
         {
          private MusicContext db;
    
          public AlbumsController()
          {
            db = new MusicContext();
          }
    
          public HttpResponseMessage GetAlbums()
          {
            return Request.CreateResponse(HttpStatusCode.OK, new {Albums = db.Albums.ToList() });
          }
    
        }
      }
