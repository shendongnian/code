    public static void LoadNewPagex(System.Type frm)
    {
        var rootFrame = Windows.UI.Xaml.Window.Current.Content as Frame;
        rootFrame.Navigate(frm);
    }
