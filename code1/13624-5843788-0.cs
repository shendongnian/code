    Private Point startPoint;
     private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          
            startPoint = e.GetPosition(null);
        }
    private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point relative = e.GetPosition(null);
                Point AbsolutePos = new Point(relative.X + this.Left, relative.Y + this.Top);
                this.Top = AbsolutePos.Y - startPoint.Y;
                this.Left = AbsolutePos.X - startPoint.X;
            }
        }
