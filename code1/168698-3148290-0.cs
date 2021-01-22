    void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage();
            int BytesToRead=100;
            WebRequest request = WebRequest.Create(new Uri("http://www.interweb.in/attachments/pc-wallpapers/16187d1222942178-nature-wallpaper-nature-summer-wallpaper.jpg", UriKind.Absolute));
            request.Timeout = -1;
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            BinaryReader reader = new BinaryReader(responseStream);
            MemoryStream memoryStream = new MemoryStream();
            byte[] bytebuffer = new byte[BytesToRead];
            int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
            while (bytesRead > 0)
            {
                memoryStream.Write(bytebuffer, 0, bytesRead);
                bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
            }
            image.BeginInit();
            memoryStream.Seek(0, SeekOrigin.Begin);
            image.StreamSource = memoryStream;
            image.EndInit();
            myImage.Source = image;
        }
