    Image I = new Image();
    BitmapImage bi = new BitmapImage();
    bi.BeginInit();
    bi.UriSource = new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Penguins.jpg", UriKind.Absolute);
    bi.EndInit();
    I.Source = bi;
    
