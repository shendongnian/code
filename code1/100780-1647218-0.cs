      public void CreateControl(IntPtr hParentWnd)
      {
        _userControl = new MyWPFUserControl();
    
        var parameters = 
          new HwndSourceParameters("", _initialWidth, _initialHeight)
          {
            ParentWindow = (IntPtr)hwndParent,
            WindowStyle = ...,          // Win32 style bits
            ExtendedWindowStyle = ...,  // Win32 ex style bits
          })
    
        _hwndSource = 
          new HwndSource(parameters) { RootVisual = _userControl };
      }
    
      public void DestroyControl()
      {
        _hwndSource.Destroy();
      }
