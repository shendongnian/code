    using YourProject.iOS.Utils;
    using YourProject.Utils;
    using System;
    using UIKit;
    using Xamarin.Forms;
    
    [assembly: Dependency(typeof(ImageResource))]
    namespace YourProject.iOS.Utils
    {
        public class ImageResource : IImageResource
        {
            public Size GetSize(string fileName)
            {
                UIImage image = UIImage.FromFile(fileName);
                return new Size((double)image.Size.Width, (double)image.Size.Height);
            }
        }
    }
