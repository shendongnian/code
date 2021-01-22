    public void Dispose()
        {
            try
            {
                Stop();
            }
            catch (Exception)
            {
            }
            // need this otherwise the process won't exit?!
            try
            {
                int ret = Marshal.FinalReleaseComObject(myPlayer);
            }
            catch (Exception)
            {
            }
            myPlayer = null;
            GC.Collect();
            //If you don't do this, it will not quit
            //http://www.eggheadcafe.com/software/aspnet/31363254/media-player-freezing-app.aspx
            for (int s = 0; s < 100; s++)
            {
                Application.DoEvents();
                Thread.Sleep(1);
            }
            GC.WaitForPendingFinalizers();
            //MessageBox.Show("Application Exiting");
        }
