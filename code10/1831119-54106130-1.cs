    public class ChartImageLayer : MapImageLayer
    {
        protected override async Task<ImageSource> GetImageAsync(BoundingBox boundingBox)
        {
            return await Task.Run(() =>
            {
                // get SevenCs chart for the provided bounding box
                System.Drawing.Bitmap chartBitmap = ...
                // convert from System.Drawing.Bitmap to System.Windows.Media.ImageSource
                using (var stream = new MemoryStream())
                {
                    chartBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Position = 0;
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = stream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    return bitmapImage;
                }
            });
        }
    }
