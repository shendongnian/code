                // Create New Process
                Process objProcess = new Process();
              
                //Get All the screens associated with this Monitor
                Screen[] screens = Screen.AllScreens;
                // Get Monitor Count
                int iMonitorCount = Screen.AllScreens.Length;
                // Get Parameters of Current Project
                string[] parametros = Environment.GetCommandLineArgs();
               // if (parametros.Length > 0)
               // {
                    //objProcess.StartInfo.FileName = parametros[0];
                   // objProcess.Start();
              //  }
                // Get Window Handle of this Form
                IntPtr hWnd = this.Handle;
                Thread.Sleep(1000);
              
                                                   
                if (IsProjectorMode)
                {
                    if (iMonitorCount > 1) // If monitor Count 2 or more
                    {
                        //Get the Dimension of the monitor
                        rectMonitor = Screen.AllScreens[1].WorkingArea;
                    }
                    else
                    {
                        //Get the Dimension of the monitor
                        rectMonitor = Screen.AllScreens[0].WorkingArea;
                    }
                       
                }
                else
                {
                    rectMonitor = Screen.AllScreens[0].WorkingArea;
            
                }
                if (hWnd != IntPtr.Zero)
                {
                    SetWindowPos(hWnd, 0,
                        rectMonitor.Left, rectMonitor.Top, rectMonitor.Width,
                        rectMonitor.Height, SWP_SHOWWINDOW);
                }
                        
            }
