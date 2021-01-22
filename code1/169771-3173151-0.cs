    public class Media : IDisposable
    {
        private readonly List<BitmapImage> m_Screens = new List<BitmapImage>();
        private readonly List<MemoryStream> m_BackingStreams = new List<MemoryStream>();
        public BitmapImage MainScreen { get; private set; }
        public List<BitmapImage> Screens
        {
            get
            {
                return m_Screens;
            }
        }
        public Media()
        {
            LoadScreens();
        }
        private void LoadScreens()
        {
            m_BackingStreams.Add(FromResourceBitmap(Properties.Resources.Screen_01));
            m_BackingStreams.Add(FromResourceBitmap(Properties.Resources.Screen_02));
            m_BackingStreams.Add(FromResourceBitmap(Properties.Resources.Screen_03));
            m_BackingStreams.Add(FromResourceBitmap(Properties.Resources.Screen_04));
            m_BackingStreams.Add(FromResourceBitmap(Properties.Resources.Screen_05));
            foreach (var stream in m_BackingStreams)
            {
                m_Screens.Add(FromResourceStream(stream));
            }
        }
        private BitmapImage FromResourceStream(Stream stream)
        {
            var result = new BitmapImage();
            result.BeginInit();
            result.StreamSource = stream;
            result.EndInit();
            return result;
        }
        private MemoryStream FromResourceBitmap(Bitmap bitmap)
        {
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            return stream;
        }
        public void Dispose()
        {
            if (m_BackingStreams.Count == 0 || m_BackingStreams == null) return;
            
            foreach (var stream in m_BackingStreams)
            {
                stream.Close();
                stream.Flush();
            }
        }
