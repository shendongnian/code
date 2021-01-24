     private void MainWindow_StateChanged(object sender, EventArgs e)
                {
                    if (this.WindowState != WindowState.Minimized)
                    {
                        this.Width = SystemParameters.PrimaryScreenWidth;
                        this.Height = SystemParameters.PrimaryScreenHeight;
                        //this.Width = SystemParameters.VirtualScreenWidth;
                        //this.Height = SystemParameters.VirtualScreenHeight;
                        //  this.MaxWidth = SystemParameters.PrimaryScreenWidth;
                        //  this.MaxHeight = SystemParameters.PrimaryScreenHeight;
        
                    }
                }
