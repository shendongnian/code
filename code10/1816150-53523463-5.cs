    private float progress = 0f;
    private void Form1_Load(object sender, EventArgs e) => timer1.Start();
    private void timer1_Tick(object sender, EventArgs e) {
        progress += 0.01f;
        if (progress >= 1.0f)
            progress = 0f;
    
        panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e) {
        e.Graphics.FillRectangle(Brushes.Green, new Rectangle(0, 0, panel1.Width, (int)(panel1.Height * progress)));
    }
