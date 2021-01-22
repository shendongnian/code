    private void DisplayWindow_MouseMove(object sender, MouseEventArgs e) {
      if (e.LeftButton == MouseButtonState.Released) {
        this.ResizeMode = System.Windows.ResizeMode.CanResizeWithGrip;
      }
    }
    private void DisplayWindow_LocationChanged(object sender, EventArgs e) {
      this.ResizeMode = System.Windows.ResizeMode.NoResize;
    }
The window's XAML had the ResizeMode="CanResizeWithGrip" setting.
