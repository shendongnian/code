    void Window1_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if( e.LeftButton == MouseButtonState.Pressed )
        {
            // this prevents win7 aerosnap
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.UpdateLayout();
            DragMove();
            // restore resize grips
            this.ResizeMode = System.Windows.ResizeMode.CanResizeWithGrip;
            this.UpdateLayout();
        }
    }
