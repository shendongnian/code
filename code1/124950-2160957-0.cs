    public System.Windows.Media.ImageSource Icon
    {
        get
        {
            if (icon == null && System.IO.File.Exists(Command))
            {
                using (System.Drawing.Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(Command))
                {
                    // This new call in WPF finally allows us to read/display 32bit Windows file icons!
                    icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                      sysicon.Handle,
                      System.Windows.Int32Rect.Empty,
                      System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                }
            }
            return icon;
        }
    }
