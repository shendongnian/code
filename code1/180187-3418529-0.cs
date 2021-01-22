                MemoryStream stream = new MemoryStream(imageBytes);
                System.Windows.Media.Imaging.BitmapImage img = new System.Windows.Media.Imaging.BitmapImage();
                img.BeginInit();
                img.StreamSource = stream;
                img.EndInit();
                return img;
