    public class PhotoController : Controller {
        public ActionResult GetPhoto() {
            ...
            return File(bytes, "image/jpeg");
        }
    }
