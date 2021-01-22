    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }
        private Microsoft.DirectX.Direct3D.Device _device;
        private Microsoft.DirectX.Direct3D.Font font;
        private Microsoft.DirectX.AudioVideoPlayback.Video _video;
        CustomVertex.PositionTextured[] vertices;
        public void Init()
        {
            PresentParameters present_params = new PresentParameters();
            present_params.Windowed = true;
            present_params.SwapEffect = SwapEffect.Discard;
            _device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, present_params);
            font = new Microsoft.DirectX.Direct3D.Font(_device, 20, 0, FontWeight.Bold, 0, false, CharacterSet.Default, Precision.Default, FontQuality.Default, PitchAndFamily.DefaultPitch, "Arial");
            _video = new Video("clock.avi");
            _video.TextureReadyToRender += new TextureRenderEventHandler(_video_TextureReadyToRender);
            _video.RenderToTexture(_device);
            
            vertices = new CustomVertex.PositionTextured[6];
            vertices[0].Position = new Vector3(1f, 1f, 0f);
            vertices[0].Tu = 0;
            vertices[0].Tv = 1;
            vertices[1].Position = new Vector3(-1f, -1f, 0f);
            vertices[1].Tu = 1;
            vertices[1].Tv = 1;
            vertices[2].Position = new Vector3(1f, -1f, 0f);
            vertices[2].Tu = 0;
            vertices[2].Tv = 0;
            vertices[3].Position = new Vector3(-1.1f, -0.99f, 0f);
            vertices[3].Tu = 1;
            vertices[3].Tv = 0;
            vertices[4].Position = new Vector3(0.99f, 1.1f, 0f);
            vertices[4].Tu = 0;
            vertices[4].Tv = 0;
            vertices[5].Position = new Vector3(-1.1f, 1.1f, 0f);
            vertices[5].Tu = 1;
            vertices[5].Tv = 1;
        }
        void _video_TextureReadyToRender(object sender, TextureRenderEventArgs e)
        {
            _device.BeginScene();
            _device.SetTexture(0, e.Texture);
            _device.VertexFormat = CustomVertex.PositionTextured.Format;
            _device.DrawUserPrimitives(PrimitiveType.TriangleList, 2, vertices);
            font.DrawText(null, "test overlay", 5, 5, Color.Red);
            _device.EndScene();
            _device.Present();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            _device.Clear(ClearFlags.Target, Color.Blue, 0.0F, 0);
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _video.Play();
        }
    }
