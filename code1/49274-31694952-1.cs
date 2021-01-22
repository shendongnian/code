    namespace HA.FacialRecognition.Enroll.ViewModels
    {
    public class PhotoCaptureViewModel : INotifyPropertyChanged
    {
        public PhotoCaptureViewModel()
        {
            StartVideo();
        }
        private DispatcherTimer Timer { get; set; }
        private Capture Capture { get; set; }
        private BitmapSource _currentFrame;
        public BitmapSource CurrentFrame
        {
            get { return _currentFrame; }
            set
            {
                if (_currentFrame != value)
                {
                    _currentFrame = value;
                    OnPropertyChanged();
                }
            }
        }
        private void StartVideo()
        {
            Capture = new Capture();
            var Timer = new DispatcherTimer();
            //framerate of 10fps
            Timer.Interval = TimeSpan.FromMilliseconds(100);
            Timer.Tick += new EventHandler(async (object s, EventArgs a) =>
            {
                //draw the image obtained from camera
                using (Image<Bgr, byte> frame = Capture.QueryFrame())
                {
                    if (frame != null)
                    {
                        CurrentFrame = ToBitmapSource(frame);
                    }
                }
            });
            Timer.Start();
        }
        public static BitmapSource ToBitmapSource(IImage image)
        {
            using (System.Drawing.Bitmap source = image.Bitmap)
            {
                IntPtr ptr = source.GetHbitmap(); //obtain the Hbitmap
                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ptr, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(ptr); //release the HBitmap
                return bs;
            }
        }
        /// <summary>
        /// Delete a GDI object
        /// </summary>
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);
        //implementation of INotifyPropertyChanged, viewmodel disposal etc
    }
