    using Android.Graphics;
    using YourProject.Droid.Utils;
    using YourProject.Utils;
    using System;
    using Xamarin.Forms;
    
    [assembly: Dependency(typeof(ImageResource))]
    namespace YourProject.Droid.Utils
    {
        public class ImageResource : Java.Lang.Object, IImageResource
        {
            public Size GetSize(string fileName)
            {
                var options = new BitmapFactory.Options
                {
                    InJustDecodeBounds = true
                };
    
                fileName = fileName.Replace('-', '_').Replace(".png", "").Replace(".jpg", "");
                var resId = Forms.Context.Resources.GetIdentifier(fileName, "drawable", Forms.Context.PackageName);
                BitmapFactory.DecodeResource(Forms.Context.Resources, resId, options);
    
                return new Size((double)options.OutWidth, (double)options.OutHeight);
            }
        }
    }
