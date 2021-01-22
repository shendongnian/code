        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _start_point = e.GetPosition(this);
            StackPanel.CaptureMouse();
        }
        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StackPanel.ReleaseMouseCapture();
        }
        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (StackPanel.IsMouseCaptured)
            {
                var p = _form.GetMousePositionWindowsForms();
                _form.Location = new System.Drawing.Point((int)(p.X - this._start_point.X), (int)(p.Y - this._start_point.Y));
            }
        }
        //Global variables;
        private Point _start_point = new Point(0, 0);
