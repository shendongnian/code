    private DataLoader loader;
    private void Form1_Load(object sender, EventArgs e) {
        loader = new DataLoader();
        loader.ObjectLoaded += loader_ObjectLoaded;
    }
    private void loader_ObjectLoaded(object sender, EventArgs e) => panel1.Invalidate();
    private void panel1_Paint(object sender, PaintEventArgs e) {
        e.Graphics.FillRectangle(Brushes.Green, new Rectangle(0, 0, panel1.Width, (int)(panel1.Height * loader.Progress)));
    }
