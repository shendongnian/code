    private void ResizePanels()
    {
        if (_changingSize)
            return; //Prevent infinite loops
        _changingSize = true;
        
        try
        {
            //Get size of the sibling window and main parent window
            Rectangle siblingRect = SafeNativeMethods.GetWindowRectangle(this.SiblingWindow);
            Rectangle parentRect = SafeNativeMethods.GetWindowRectangle(this.ParentWindow);
            //Calculate position of sibling window in screen coordinates
            SafeNativeMethods.POINT topLeft = new SafeNativeMethods.POINT(siblingRect.Left, siblingRect.Top);
            SafeNativeMethods.ScreenToClient(this.ParentWindow, ref topLeft);
            //Decrease size of the sibling window
            int newHeight = parentRect.Height - topLeft.Y - _panelContainer.Height;
            SafeNativeMethods.SetWindowPos(this.SiblingWindow, IntPtr.Zero, 0, 0, siblingRect.Width, newHeight, SafeNativeMethods.SWP_NOMOVE | SafeNativeMethods.SWP_NOZORDER);
            //Move the bar to correct position
            _panelContainer.Left = topLeft.X;
            _panelContainer.Top = topLeft.Y + newHeight;
            //Set correct height of the panel container
            _panelContainer.Width = siblingRect.Width;
        }
        finally
        {
            _changingSize = false;
        }
    }
