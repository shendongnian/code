    using System.Windows.Interop;
    ...
    using (Icon i = Icon.FromHandle(shinfo.hIcon))
    {
        ImageSource img = Imaging.CreateBitmapSourceFromHIcon(
                                i.Handle,
                                new Int32Rect(0,0,i.Width, i.Height),
                                BitmapSizeOptions.FromEmptyOptions());
    }
