    // put this inside the window's class constructor
    Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            private void OnApplicationExit(object sender, EventArgs e)
            {
    
                try
                {
                    if (trayIcon != null)
                    {
                        trayIcon.Visible = false;
                        trayIcon.Icon = null; // required to make icon disappear
                        trayIcon.Dispose();
                        trayIcon = null;
                    }
    
                }
                catch (Exception ex)
                {
                    // handle the error
                }
            }
