    public static void SetProxy(WebView webView, string host, int port, bool bypass)
    {
        Context appContext = webView.Context.ApplicationContext;
        JavaSystem.SetProperty("http.proxyHost", host);
        JavaSystem.SetProperty("http.proxyPort", port + "");
        JavaSystem.SetProperty("https.proxyHost", host);
        JavaSystem.SetProperty("https.proxyPort", port + "");
        if (bypass)
            JavaSystem.SetProperty("http.nonProxyHosts", BYPASS_PATTERN);
    
        try
        {
            Class applictionCls = Class.ForName(APPLICATION_CLASS_NAME);
            Field loadedApkField = applictionCls.GetField("mLoadedApk");
            loadedApkField.Accessible = true;
            Object loadedApk = loadedApkField.Get(appContext);
            Class loadedApkCls = Class.ForName("android.app.LoadedApk");
            Field receiversField = loadedApkCls.GetDeclaredField("mReceivers");
            receiversField.Accessible = true;
            ArrayMap receivers = (ArrayMap) receiversField.Get(loadedApk);
            foreach (Object receiverMap in receivers.Values())
            {
                foreach (Object rec in Extensions.JavaCast<ArrayMap>(receiverMap).KeySet())
                {
                    Class clazz = rec.Class;
                    if (clazz.Name.Contains("ProxyChangeListener"))
                    {
                        Method onReceiveMethod = clazz.GetDeclaredMethod("onReceive", Class.FromType(typeof(Context)), Class.FromType(typeof(Intent)));
                        Intent intent = new Intent(Android.Net.Proxy.ProxyChangeAction);
    
                        onReceiveMethod.Invoke(rec, appContext, intent);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }
