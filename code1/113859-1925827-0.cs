    System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
    {
        System.Windows.Media.Imaging.BitmapImage bi = new BitmapImage();
        ConvertToBitmapFromBuffer(bi, imageArgs.Result.Image);
        bitmapCallback.Invoke(bi);
    });
