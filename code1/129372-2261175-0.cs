    public abstract class AbstractConverter : IImageHandler
    {
        public AbstractConverter(IImageHandler next)
        {
            output = next;
        }
        public void HandleImage(Bitmap b)
        {
            var outBitmap = Convert(b);
            output.HandleImage(outBitmap);
        }
        protected abstract Bitmap Convert(Bitmap input);
        private IImageHandler output;
    }
    public interface IImageHandler
    {
        void HandleImage(Bitmap b);
    }
