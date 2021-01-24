    public class PhotosController {
        IPhotoServiceFactory _factory;
        public PhotosController(IPhotoServiceFactory factory){
           _factory = factory;
        } 
        public IHttpActionResult GetPhoto() {
           var photoServiceToUse = _factory.Create(User);
           var photo = photoServiceToUse.CreatePhoto(params);
           return Ok(photo);
        }
    }
