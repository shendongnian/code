    System.Windows.Media.Imaging.BitmapImage bi = null;
    using(AutoResetEvent are = new AutoResetEvent(false))
    {
        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            bi = new BitmapImage();
            are.Set();
        });
        are.WaitOne();
    }
    ConvertToBitmapFromBuffer(bi, imageArgs.Result.Image);
    bitmapCallback.Invoke(bi);
