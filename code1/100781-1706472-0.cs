                    int WS_CHILD = 0x40000000;
                    int WS_VISIBLE = 0x10000000;
    
                    // paint wpf on int hParentWnd
                    myWindow = new MyWpfWindow();
    
                    // First it creates an HwndSource, whose parameters are similar to CreateWindow:
                    HwndSource otxHwndSource = new HwndSource(
                                            0,                          // class style
                                            WS_VISIBLE | WS_CHILD,      // style
                                            0,                          // exstyle
                                            10, 10, 200, 400,
                                            "MyWpfWindow",             // NAME
                                            (IntPtr)hParentWnd          // parent window
                                            );
    
                    otxHwndSource.RootVisual = ...;
    
                    // following must be set to prcess key events
                    myHwndSource.AddHook(new HwndSourceHook(ChildHwndSourceHook));
