        private SaveFileDialog save = new SaveFileDialog();
        private void DownloadFile(string url, string fileName)
        {
            if (_isBusy) return;
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            save.FileName = fileName;
            if (save.ShowDialog() == DialogResult.OK)
            {
                _isBusy = true;
                var output = save.FileName;
                MessageBox.Show($"{fileName} will start downloading from {url}");
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileCompleted += (sender, args) =>
                    {
                        MessageBox.Show($"{fileName} Complete!");
                        Process.Start(output);
                        _isBusy = false;
                    };
                    client.DownloadProgressChanged += (sender, args) => progressBar1.Value = args.ProgressPercentage;
                    client.DownloadFileAsync(new Uri(url), output);
                }
            }   
        }
