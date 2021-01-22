            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = File.Open("image.png", FileMode.Open);
            image.EndInit();
            System.Windows.Clipboard.SetImage(image);
