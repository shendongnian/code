    void Window1_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if( e.LeftButton == MouseButtonState.Pressed )
        {
            // this prevents win7 aerosnap
            if( this.ResizeMode != System.Windows.ResizeMode.NoResize )
            {
                this.ResizeMode = System.Windows.ResizeMode.NoResize;
                this.UpdateLayout();
            }
            DragMove();
        }
    }
    void Window1_MouseUp( object sender, MouseButtonEventArgs e )
    {
        if( this.ResizeMode == System.Windows.ResizeMode.NoResize )
        {
            // restore resize grips
            this.ResizeMode = System.Windows.ResizeMode.CanResizeWithGrip;
            this.UpdateLayout();
        }
    }
