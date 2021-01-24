    public Form1()
    {
        InitializeComponent();
        pictureBox1.Paint += new PaintEventHandler(this.pictureBox1_Paint);
        pictureBox2.Paint += new PaintEventHandler(this.pictureBox2_Paint);
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(40, 40, 20, 20));
        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(40, 80, 20, 20));
        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(80, 40, 20, 20));
        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(80, 80, 20, 20));
    }
    private void pictureBox2_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(40, 40, 20, 20));
        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(40, 80, 20, 20));
        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(80, 40, 20, 20));
        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(80, 80, 20, 20));
    }
