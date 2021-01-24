    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                bool error = false;
                string url = txtUrl.Text;
                int counter = 1;
    
                btnStart.IsEnabled = false;
                await Task.Factory.StartNew(() =>
                {
                    while (!error)
                    {
                        Dispatcher.Invoke(() => { lblProgress.Content = "Downloading page " + counter.ToString() + ":"; });
    
                        using (WebClient wc = new WebClient())
                        {
                            try
                            {
                                string targetPath = $"c:\\temp\\downloads\\file{counter}.tmp";
                                wc.DownloadFile(new Uri(url), targetPath);
                            }
                            catch { error = true; }
                        }
                        counter++;
                    }
                });
                btnStart.IsEnabled = true;
            }
        }
    }
