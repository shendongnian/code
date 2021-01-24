    private void Timer1_Tick(object sender, EventArgs e)
    {
      using (var b = Screenshot())
      {
        label1.Text = b.GetPixel(Cursor.Position.X, Cursor.Position.Y).Name;
        label2.Text = Cursor.Position.ToString();
      }
    }
    private static Bitmap Screenshot()
    {
      var Screen = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
      var g = Graphics.FromImage(Screen);
      g.CopyFromScreen(SystemInformation.VirtualScreen.X, SystemInformation.VirtualScreen.Y, 0, 0, Screen.Size);
      return Screen;
    }
