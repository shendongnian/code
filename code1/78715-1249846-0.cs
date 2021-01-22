    private void win_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        click = new Point(e.GetPosition(this).X, e.GetPosition(this).Y);
        win.WindowState = WindowState.Normal;
    }
    private void Window_MouseMove(object sender, MouseEventArgs e)
    {
        this.Left += e.GetPosition(this).X - click.X;
        this.Top += e.GetPosition(this).Y - click.Y;
    }
    private void win_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        win.WindowState = WindowState.Maximized;
    }
