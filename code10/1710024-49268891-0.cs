    private void _MouseDown(object sender, MouseEventArgs mevent)
        {
            MState = MouseState.Down;
            (sender as Button).Enabled = false;
            (sender as Button).Enabled = true;
            (sender as Button).Refresh();
            Invalidate();
        }
