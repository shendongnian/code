    public partial class MDIParent : Form
    {
        private MdiClient mdiBackground = null;
        private Bitmap BackGroundImage = null;
        public MDIParent()
        {
            InitializeComponent();
            //Specify an existing Resources' Image
            BackGroundImage = new Bitmap(Properties.Resources.[Some Res Image] as Bitmap);
            BackGroundImage.SetResolution(this.DeviceDpi, this.DeviceDpi);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mdiBackground = this.Controls.OfType<MdiClient>().First();
            mdiBackground.Paint += (s, evt) => {
                evt.Graphics.DrawImage(BackGroundImage,
                        (mdiBackground.Width - BackGroundImage.Width) / 2.0F,
                        (mdiBackground.Height - BackGroundImage.Height) / 2.0F);
            };
            //Show some child Forms on start-up
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.mdiBackground != null) mdiBackground.Invalidate();
        }
        private void MDIParent_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BackGroundImage != null) BackGroundImage.Dispose();
        }
    }
