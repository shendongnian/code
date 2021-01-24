    private void MainWindow_StateChanged(object sender, EventArgs e)
    {
       if (this.WindowState != WindowState.Minimized)
       {
                            this.Width = SystemParameters.PrimaryScreenWidth;
                            this.Height = SystemParameters.PrimaryScreenHeight;
                            //this.Width = SystemParameters.VirtualScreenWidth;
                            //this.Height =SystemParameters.VirtualScreenHeight;
                            //this.Width = SystemParameters.WorkArea.Width                            
                            //this.Height =SystemParameters.WorkArea.Height;
                         }
       }
