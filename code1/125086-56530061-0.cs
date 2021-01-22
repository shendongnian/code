    private float _angle;
    public Form1()
    {
        InitializeComponent();
    }
    private void PictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        (float centerX, float centerY) = GetCenter(pictureBox1.ClientRectangle);
        _angle = (float)(Math.Atan2(e.Y - centerY, e.X - centerX) * 180.0 / Math.PI);
        pictureBox1.Invalidate();
    }
    private void PictureBox_Paint(object sender, PaintEventArgs e)
    {
        Bitmap image = Properties.Resources.ExampleImage;
        float scale = (float)pictureBox1.Width / image.Width;
        (float centerX, float centerY) = GetCenter(e.ClipRectangle);
        e.Graphics.TranslateTransform(centerX, centerY);
        e.Graphics.RotateTransform(_angle);
        e.Graphics.TranslateTransform(-centerX, -centerY);
        e.Graphics.ScaleTransform(scale, scale);
        e.Graphics.DrawImage(image, 0, 0);
    }
    private static (float, float) GetCenter(Rectangle rect)
    {
        float centerX = (rect.Left + rect.Right) * 0.5f;
        float centerY = (rect.Top + rect.Bottom) * 0.5f;
        return (centerX, centerY);
    }
