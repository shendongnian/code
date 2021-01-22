    public Point mouseLocation;
    private void frmInstallDevice_MouseDown(object sender, MouseEventArgs e)
    {
      mouseLocation = new Point(-e.X, -e.Y);
    }
    private void frmInstallDevice_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        Point mousePos = Control.MousePosition;
        mousePos.Offset(mouseLocation.X, mouseLocation.Y);
        Location = mousePos;
      }
    }
