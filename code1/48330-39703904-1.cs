       Socket server = null;
        MemoryStream ms;
        IPEndPoint endpoint = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);
            endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
        }
        private void btn_browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(path);
            textPath.Text = path;
        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {                
                ms = new MemoryStream();
                Bitmap bmp = new Bitmap(this.openFileDialog1.FileName);
                bmp.Save(ms, ImageFormat.Jpeg);
                byte[] byteArray = ms.ToArray();
                server.Connect(endpoint);
                server.SendTo(byteArray, endpoint);
                }
            }
            catch (Exception ex)
            {
            }
