    Bitmap Gear = null;
    System.Windows.Forms.Timer GearTimer = new System.Windows.Forms.Timer();
    int GearRotateSpeed = 100;
    int GearRotationAngle = 24;
    int GearCurrentRotationAngle = 0;
    public Form1() {
        InitializeComponent();
        Gear = (Bitmap)Image.FromFile(@"File Path").Clone();
        GearTimer.Tick += (s, e) => { pictureBox1.Invalidate(); };
    }
    private void pictureBox1_MouseEnter(object sender, EventArgs e) {
        GearTimer.Interval = GearRotateSpeed;
        GearTimer.Start();
    }
    private void pictureBox1_MouseLeave(object sender, EventArgs e) {
        GearTimer.Stop();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e) {
        PictureBox pBox = sender as PictureBox;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        PointF CenterImage = new PointF(pBox.Width / 2, pBox.Height / 2);
        using (Matrix matrix = new Matrix()) {
            matrix.RotateAt(GearCurrentRotationAngle, CenterImage);
            e.Graphics.Transform = matrix;
            e.Graphics.DrawImage(Gear, pBox.ClientRectangle, new Rectangle(Point.Empty, Gear.Size), GraphicsUnit.Pixel);
        }
        GearCurrentRotationAngle += GearRotationAngle;
        if (GearCurrentRotationAngle > 360) GearCurrentRotationAngle = GearRotationAngle;
    }
