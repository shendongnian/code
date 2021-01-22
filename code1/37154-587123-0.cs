    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern IntPtr WindowFromPoint(Point pnt);
    private void Form1_MouseMove(object sender, MouseEventArgs e) {
      IntPtr hWnd = WindowFromPoint(Control.MousePosition);
      if (hWnd != IntPtr.Zero) {
        Control ctl = Control.FromHandle(hWnd);
        if (ctl != null) label1.Text = ctl.Name;
      }
    }
    private void button1_Click(object sender, EventArgs e) {
      // Need to capture to see mouse move messages...
      this.Capture = true;
    }
