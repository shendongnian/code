    private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp = (StackPanel)sender;
            Panel.SetZIndex(sp, 99999);
            sp.CaptureMouse(); //This
        }
        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp = (StackPanel)sender;
            Panel.SetZIndex(sp, -10);
            sp.ReleaseMouseCapture(); //And this
        } 
