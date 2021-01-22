    public partial class Form1 : Form
    {
        uint[] _Pixels { get; set; }
        Bitmap _Bitmap { get; set; }
        GCHandle _Handle { get; set; }
        IntPtr _Addr { get; set; }
        public Form1()
        {
            InitializeComponent();
            int imageWidth = 100; //1920;
            int imageHeight = 100; // 1080;
            PixelFormat fmt = PixelFormat.Format32bppRgb;
            int pixelFormatSize = Image.GetPixelFormatSize(fmt);
            int stride = imageWidth * pixelFormatSize;
            int padding = 32 - (stride % 32);
            if (padding < 32)
            {
                stride += padding;
            }
            _Pixels = new uint[(stride / 32) * imageHeight + 1];
             _Handle = GCHandle.Alloc(_Pixels, GCHandleType.Pinned);
            _Addr = Marshal.UnsafeAddrOfPinnedArrayElement(_Pixels, 0);
            _Bitmap = new Bitmap(imageWidth, imageHeight, stride / 8, fmt, _Addr);
            pictureBox1.Image = _Bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _Pixels.Length; i++)
            {
                _Pixels[i] = ((uint)(255 | (255 << 8) | (255 << 16) | 0xff000000));
            }
            
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Addr = IntPtr.Zero;
            if (_Handle.IsAllocated)
            {
                _Handle.Free();
            }
            _Bitmap.Dispose();
            _Bitmap = null;
            _Pixels = null;
        }
    }
