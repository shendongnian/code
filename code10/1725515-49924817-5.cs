    public interface IBitmapService {
        void SaveBitmapAsPngImage(Uri path, BitmapSource renderBitmap);
    }
    public interface IFileSystem {
        Stream OpenOrCreateFileStream(string path);
    }
    public class PhysicalFileSystem : IFileSystem {
        public Stream OpenOrCreateFileStream(string path) {
            return new FileStream(path, FileMode.OpenOrCreate);
        }
    }
    public class BitmapService : IBitmapService {
        private readonly IFileSystem fileSystem;
        
        public BitmapService(IFileSystem fileSystem) {
            this.fileSystem = fileSystem;
        }
        // SaveBitmapAsPngImage(path, renderBitmap);
        public void SaveBitmapAsPngImage(Uri path, BitmapSource renderBitmap) {
            // Create a file stream for saving image
            using (var outStream = fileSystem.OpenOrCreateFileStream(path.LocalPath)) {
                // Use png encoder for our data
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                // push the rendered bitmap to it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                // save the data to the stream
                encoder.Save(outStream);
            }
        }
    }
    public interface IImageDrawingCombiner {
        void CombineDrawingsIntoImage(Uri path, Canvas surface);
    }
    public class ImageDrawingCombiner : IImageDrawingCombiner {
        private readonly IBitmapService service;
        
        public ImageDrawingCombiner(IBitmapService service) {
            this.service = service;
        }
        /// <summary>
        ///  Save image to a specified location in path
        /// </summary>
        /// <param name="path">Location to save the image</param>
        /// <param name="surface">The image as canvas</param>
        public void CombineDrawingsIntoImage(Uri path, Canvas surface) {
            var size = new Size(surface.ActualWidth, surface.ActualHeight);
            // Create a render bitmap and push the surface to it
            var renderBitmap = new RenderTargetBitmap(
                (int)size.Width, (int)size.Height, 96d, 96d, PixelFormats.Pbgra32);
            renderBitmap.Render(surface);
            service.SaveBitmapAsPngImage(path, renderBitmap);
        }
    }
    
