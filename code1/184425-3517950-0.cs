            private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //<============================================================================
            //  Update image preview when file is selected from listBox1  
            //<============================================================================
            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            BitmapImage myBitmapImage = new BitmapImage();
            string curItem = destinationFolder + "\\" + listBox1.SelectedItem.ToString();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@curItem);
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            uploadImage.Source = myBitmapImage;
        }
