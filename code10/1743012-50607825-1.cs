        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                var copyPath = Path.Combine(
                   Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                   "meme" + rand.Next() + ".mp4");
                var sourceDir = Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().Location);
                File.Copy(Path.Combine(sourceDir, "meme.mp4"), copyPath, true);
            }
            e.Cancel = true;
            new MainWindow(0).Show();
        }
