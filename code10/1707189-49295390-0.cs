        // Service the UI uses
        public class ImageService<T>
        {
              public ImageService(T t)
              {
                   _imageProvider = t;
              }
              private IImageProvider _imageProvider;
              public void SaveImage(byte[] data)
              {
                string fileName = "some_generated_name.jpg"
                _imageProvider.Save(fileName, data);
              }
        }
 
