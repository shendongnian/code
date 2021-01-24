    private readonly Bitmap screen = new Bitmap(1, 1);
    private static readonly Size size = new Size(1, 1);
    private void Timer1_Tick(object sender, EventArgs e)
    {
      using (var g = Graphics.FromImage(screen))
      {
        g.CopyFromScreen(Cursor.Position.X, Cursor.Position.Y, 0, 0, size);
        label1.Text = screen.GetPixel(0, 0).Name;
        label2.Text = Cursor.Position.ToString();
      }
    }
