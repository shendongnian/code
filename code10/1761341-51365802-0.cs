        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                ImageSource imageSource = new BitmapImage(new Uri(fd.FileName));    
                imgPhoto.Source = imageSource;
            }
        }
