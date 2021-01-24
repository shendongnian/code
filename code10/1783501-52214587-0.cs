    public class MakeViewSnapshot : IViewSnapShot
    {
        Task<byte[]> IViewSnapShot.CaptureAsync(Xamarin.Forms.View view)
        {
            var nativeView = view.GetRenderer().View;
            var wasDrawingCacheEnabled = nativeView.DrawingCacheEnabled;
            nativeView.DrawingCacheEnabled = true;
            nativeView.BuildDrawingCache(false);
            Bitmap bitmap = nativeView.GetDrawingCache(false);
            // TODO: Save bitmap and return filepath
            nativeView.DrawingCacheEnabled = wasDrawingCacheEnabled;
    
            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
    
            return Task.FromResult(bitmapData);
        }
    }
