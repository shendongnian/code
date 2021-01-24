    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    Bitmap gear = null;
    System.Windows.Forms.Timer gearTimer = new System.Windows.Forms.Timer();
    int gearRotateSpeed = 100;
    int gearRotationAngle = 24;
    int gearCurrentRotationAngle = 0;
    public Form1() {
        InitializeComponent();
        gear = (Bitmap)Image.FromFile(@"File Path").Clone();
        gearTimer.Tick += (s, e) => { pictureBox1.Invalidate(); };
    }
    private void pictureBox1_MouseEnter(object sender, EventArgs e) {
        gearTimer.Interval = gearRotateSpeed;
        gearTimer.Start();
    }
    private void pictureBox1_MouseLeave(object sender, EventArgs e) => gearTimer.Stop();
    private void pictureBox1_Paint(object sender, PaintEventArgs e) {
        PictureBox pBox = sender as PictureBox;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        PointF centerImage = new PointF(pBox.Width / 2, pBox.Height / 2);
        using (Matrix mx = new Matrix()) {
            mx.RotateAt(gearCurrentRotationAngle, centerImage);
            e.Graphics.Transform = mx;
            e.Graphics.DrawImage(gear, pBox.ClientRectangle, new Rectangle(Point.Empty, gear.Size), GraphicsUnit.Pixel);
        }
        gearCurrentRotationAngle += gearRotationAngle;
        if (gearCurrentRotationAngle > 360) gearCurrentRotationAngle = gearRotationAngle;
    }
