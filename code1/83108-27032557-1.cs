        private void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Application.Current.Resources["AutoPilotThreadStatus"] = true;
                Thread.CurrentThread.Name = "ResumeAutoPilot";
                Thread.CurrentThread.IsBackground = true;
                AutoPilotHandler.ResumeAutoPilot();
            });
        }
        public static void ResumeAutoPilot()
        {
            while ((bool)Application.Current.Resources["AutoPilotThreadStatus"])
            {
                CheckAutoPilotThreadStatus();
                var searchYoutube = YoutubeHandler.Search("small truck");
                CheckAutoPilotThreadStatus();
                SaveVideosToDatabase(searchYoutube);
                CheckAutoPilotThreadStatus();
            }
        }
        public static void CheckAutoPilotThreadStatus()
        {
            if (!(bool)Application.Current.Resources["AutoPilotThreadStatus"])
            {
                KillCurrentThread();
            }
        }
        public static void KillCurrentThread()
        {
            Thread.CurrentThread.Abort();
        }
