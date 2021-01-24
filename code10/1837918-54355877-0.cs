    [assembly: Dependency (typeof (PhotoOverlayiOS))]
    namespace UsingDependencyService.iOS
    {
        public class PhotoOverlayiOS : IPhotoOverlay
        {
    
            public object GetImageOverlayAsync()
            {
                Func<object> func = CreateOverlay;
    
                return func;
            }
    
            public object CreateOverlay()
            {
                var imageView = new UIImageView(UIImage.FromBundle("face-template.png"));
                imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
    
                var screen = UIScreen.MainScreen.Bounds;
                imageView.Frame = screen;
    
                return imageView;
            }  
        }
    }
