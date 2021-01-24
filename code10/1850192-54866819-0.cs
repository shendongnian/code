    static readonly Guid SID_SWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
    internal interface IServiceProvider
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object QueryService(ref Guid guidService, ref Guid riid);
    }
    private void WebBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
        IServiceProvider serviceProvider = (IServiceProvider)webBrowser.Document;
        Guid serviceGuid = SID_SWebBrowserApp;
        Guid iid = typeof(SHDocVw.IWebBrowser2).GUID;
        SHDocVw.IWebBrowser2 myWebBrowser2 = (SHDocVw.IWebBrowser2)serviceProvider.QueryService(ref serviceGuid, ref iid);
        SHDocVw.DWebBrowserEvents_Event wbEvents = (SHDocVw.DWebBrowserEvents_Event)myWebBrowser2;
        wbEvents.NewWindow += new SHDocVw.DWebBrowserEvents_NewWindowEventHandler(OnWebBrowserNewWindow);
    }
    private void OnWebBrowserNewWindow(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers,
        ref bool Processed)
    {
        Processed = true;
        webBrowser.Navigate(URL);
    }
