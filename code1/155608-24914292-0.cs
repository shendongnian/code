    public static class IImageExtensions
    {
        // http://stackoverflow.com/questions/20825497/difference-between-using-and-dispose-call-in-c-sharp 
        public static void FreeMem(this IImage image)
        {
            using (image)
            {
                using (image.Bitmap)
                {
                }
            }
            //image.Bitmap.Dispose();
            //image.Dispose();
        }
    }
