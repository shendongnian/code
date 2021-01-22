    private void UploadImage_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = false;
                dlg.Filter = "All files (*.*)|*.*|PNG Images (*.png)|*.png";
    
                bool? retval = dlg.ShowDialog();
    
                if (retval != null &amp;&amp; retval == true)
                {
                    UploadFile(dlg.File.Name, dlg.File.OpenRead());
                    StatusText.Text = dlg.File.Name;
                }
                else
                {
                    StatusText.Text = "No file selected...";
                }
            }
    
            private void UploadFile(string fileName, Stream data)
            {
                string host = Application.Current.Host.Source.AbsoluteUri;
                host = host.Remove(host.IndexOf("/ClientBin"));
    
                UriBuilder ub = new UriBuilder(host + "/receiver.ashx");
                ub.Query = string.Format("filename={0}", fileName);
                WebClient c = new WebClient();
                c.OpenWriteCompleted += (sender, e) =&gt;
                {
                    PushData(data, e.Result);
                    e.Result.Close();
                    data.Close();
                };
                c.WriteStreamClosed += (sender, e) =&gt;
                {
                    LoadImage(fileName);
                };
                c.OpenWriteAsync(ub.Uri);
            }
    
            private void LoadImage(string fileName)
            {
                //
                // Creating WebClient object and setting up events
                //
                WebClient downloader = new WebClient();
                downloader.OpenReadCompleted += new OpenReadCompletedEventHandler(downloader_OpenReadCompleted);
                //downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloader_DownloadProgressChanged);
    
                //
                // Specify Image to load
                //
                string host = Application.Current.Host.Source.AbsoluteUri;
                host = host.Remove(host.IndexOf("/ClientBin"));
    
                fileName = host + "/images/" + fileName;
                downloader.OpenReadAsync(new Uri(fileName, UriKind.Absolute));
            }
    
            void downloader_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
            {
                //
                // Create a new BitmapImage and load the stream
                //
                BitmapImage loadedImage = new BitmapImage();
                loadedImage.SetSource(e.Result);
    
                //
                // Setting our BitmapImage as the source of a imageControl control I have in XAML
                //
                MainImage.Source = loadedImage;
            } 
    
            private void PushData(Stream input, Stream output)
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
    
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
                {
                    output.Write(buffer, 0, bytesRead);
                }
            }
