    /// <summary>
            /// Set the max size of the application window taking into account the current monitor
            /// </summary>
            public static void SetMaxSizeWindow(ioConnect _receiver)
            {
                Point absoluteScreenPos = _receiver.PointToScreen(Mouse.GetPosition(_receiver));
    
                if (System.Windows.SystemParameters.VirtualScreenLeft == System.Windows.SystemParameters.WorkArea.Left)
                {
                    //Primary Monitor is on the Left
                    if (absoluteScreenPos.X <= System.Windows.SystemParameters.PrimaryScreenWidth)
                    {
                        //Primary monitor
                        _receiver.WindowApplication.MaxWidth = System.Windows.SystemParameters.WorkArea.Width;
                        _receiver.WindowApplication.MaxHeight = System.Windows.SystemParameters.WorkArea.Height;
                    }
                    else
                    {
                        //Secondary monitor
                        _receiver.WindowApplication.MaxWidth = System.Windows.SystemParameters.VirtualScreenWidth - System.Windows.SystemParameters.WorkArea.Width;
                        _receiver.WindowApplication.MaxHeight = System.Windows.SystemParameters.VirtualScreenHeight;
                    }
    
                }
    
                if (System.Windows.SystemParameters.VirtualScreenLeft < 0)
                {
                    //Primary Monitor is on the Right
                    if (absoluteScreenPos.X > 0)
                    {
                        //Primary monitor
                        _receiver.WindowApplication.MaxWidth = System.Windows.SystemParameters.WorkArea.Width;
                        _receiver.WindowApplication.MaxHeight = System.Windows.SystemParameters.WorkArea.Height;
                    }
                    else
                    {
                        //Secondary monitor
                        _receiver.WindowApplication.MaxWidth = System.Windows.SystemParameters.VirtualScreenWidth - System.Windows.SystemParameters.WorkArea.Width;
                        _receiver.WindowApplication.MaxHeight = System.Windows.SystemParameters.VirtualScreenHeight;
                    }
                }
            }`enter code here
