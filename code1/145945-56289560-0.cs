    BitmapImage loadPhoto(string path)
        {
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.CacheOption = BitmapCacheOption.OnLoad;
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;            
            bmi.UriSource = new Uri(path);
            bmi.EndInit();
            return bmi;
        }
