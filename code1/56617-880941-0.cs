        /// <summary>
        /// Minimizes all running applications and captures desktop as image
        /// Note: Requires reference to "Microsoft Shell Controls and Automation"
        /// </summary>
        /// <returns>Image of desktop</returns>
        private Image DesktopImage() {
            //May want to play around with the delay.
            TimeSpan ToggleDesktopDelay = new TimeSpan(0, 0, 0, 0, 150);
            Shell32.ShellClass ShellReference = null;
            Bitmap WorkingImage = null;
            Graphics WorkingGraphics = null;
            Rectangle TargetArea = Screen.PrimaryScreen.WorkingArea;
            Image ReturnImage = null;
            try
            {
                ShellReference = new Shell32.ShellClass();
                ShellReference.ToggleDesktop();
                System.Threading.Thread.Sleep(ToggleDesktopDelay);
                WorkingImage = new Bitmap(TargetArea.Width,
                    TargetArea.Height);
                WorkingGraphics = Graphics.FromImage(WorkingImage);
                WorkingGraphics.CopyFromScreen(TargetArea.X, TargetArea.X, 0, 0, TargetArea.Size);
                System.Threading.Thread.Sleep(ToggleDesktopDelay);
                ShellReference.ToggleDesktop();
                ReturnImage = (Image)WorkingImage.Clone();
            }
            catch
            {
                System.Diagnostics.Debugger.Break();
                //...
            }
            finally
            {
                WorkingGraphics.Dispose();
                WorkingImage.Dispose();
            }
            return ReturnImage;
        }
