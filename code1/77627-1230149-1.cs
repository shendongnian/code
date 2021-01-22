    public class UploadedImage : IDisposable
    {
        private Bitmap _img = null;
        private Stream _baseStream = null;
        /// <summary>
        /// The image object.  This must always belong to BaseStream, or weird things can happen.
        /// </summary>
        public Bitmap Img
        {
            [DebuggerStepThrough]
            get { return _img; }
            [DebuggerStepThrough]
            set { _img = value; }
        }
        /// <summary>
        /// The stream that stores the image.  This must ALWAYS belong to Img, or weird things can happen.
        /// </summary>
        public Stream BaseStream
        {
            [DebuggerStepThrough]
            get { return _baseStream; }
            [DebuggerStepThrough]
            set { _baseStream = value; }
        }
        [DebuggerStepThrough]
        public void Dispose()
        {
            if (Img != null)
                Img.Dispose();
            if (BaseStream != null)
                BaseStream.Close();
            _attached = false;
        }
    }
