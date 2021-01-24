    public Form1()
    {
       InitializeComponent();
       pictureBox1.Dock = DockStyle.Fill;
       pictureBox1.BorderStyle = BorderStyle.FixedSingle;
       Controls.Add(pictureBox1);
       FormBorderStyle = FormBorderStyle.None;
       KeyPreview = true;
       Size = _lastBmp.Size;
       TopMost = true;
       var timer = new Timer();
       timer.Interval = 100;
       timer.Tick += timer_Tick;
       timer.Start();
    }
