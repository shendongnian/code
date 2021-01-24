     void worker_DoWork(object sender, DoWorkEventArgs e) {
        [DllImport(@"M:\GolangProjects\PatcherDLL\patcher.dll", EntryPoint = "ProgressValue")]
         static extern int ProgressValue();
        
        public partial class MainWindow : Window {
        var task = Task.Factory.StartNew(() => {
                        DownloadFile();
                    });
        
                    while (!task.IsCompleted)
                    {
                        Thread.Sleep(100);
        
                        string downloadSpeedFormatted = "";
        
                        if (DownloadSpeedValue()/1000 > 999)
                        {
                            downloadSpeedFormatted = Math.Round((double) DownloadSpeedValue() / 1000000, 2) + " MB/s";
                        } else
                        {
                            downloadSpeedFormatted = DownloadSpeedValue() / 1000 + " kb/s";
                        }
        
                        Dispatcher.BeginInvoke(new Action(delegate {
                            progressbar1.Value = ProgressValue();
                            progressPercent1.Text = ProgressValue() + "%";
                            downloadSpeeds.Content = downloadSpeedFormatted;
                        }));
                    }
        }
    }
