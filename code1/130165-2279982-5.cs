    private void headerArea_PreviewMouseDown(object sender, MouseButtonEventArgs e)
           {               
              switch (e.ChangedButton)
                {
                  case MouseButton.Right:
                       {
                          // need to get handle of window
                          WindowInteropHelper _helper = new WindowInteropHelper(this);
                          //translate mouse cursor porition to screen coordinates
                          Point p = PointToScreen(e.GetPosition(this));
                          //get handler of system menu
                          IntPtr systemMenuHandle = GetSystemMenu(_helper.Handle, false);
    
                          RECT rect = new RECT();
                          // and calling application menu at mouse position.
                          int menuItem = TrackPopupMenu(systemMenuHandle.ToInt32(), 1,(int)p.X, (int) p.Y, 0, _helper.Handle.ToInt32(), ref rect);
                          break;
                       }                   
                 }   
           }
