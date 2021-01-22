    public class ImageController : Controller
    {
        public ActionResult Show( int id )
        {
            var imageData = ...get bytes from database...
            return File( imageData, "image/jpg" );
        }
    }
