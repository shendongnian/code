    public class MyBrowser : WebBrowser
    {
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public MyBrowser()
        {
        }
        protected override WebBrowserSiteBase CreateWebBrowserSiteBase()
        {
            var manager = new NewWindowManagerWebBrowserSite(this);
            return manager;
        }
        protected class NewWindowManagerWebBrowserSite : WebBrowserSite, IServiceProvider, IDocHostShowUI
        {
            private readonly NewWindowManager _manager;
            public NewWindowManagerWebBrowserSite(WebBrowser host)
                : base(host)
            {
                _manager = new NewWindowManager();
            }
            public int ShowMessage(IntPtr hwnd, string lpstrText, string lpstrCaption, int dwType, string lpstrHelpFile, int dwHelpContext, out int lpResult)
            {
                lpResult = 0;
                return Constants.S_OK; //  S_OK	Host displayed its UI. MSHTML does not display its message box.
            }
            // Only files of types .chm and .htm are supported as help files.
            public int ShowHelp(IntPtr hwnd, string pszHelpFile, uint uCommand, uint dwData, POINT ptMouse, object pDispatchObjectHit)
            {
                return Constants.S_OK; //  S_OK	Host displayed its UI. MSHTML does not display its message box.
            }
            #region Implementation of IServiceProvider
            public int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
            {
                if ((guidService == Constants.IID_INewWindowManager && riid == Constants.IID_INewWindowManager))
                {
                    ppvObject = Marshal.GetComInterfaceForObject(_manager, typeof(INewWindowManager));
                    if (ppvObject != IntPtr.Zero)
                    {
                        return Constants.S_OK;
                    }
                }
                ppvObject = IntPtr.Zero;
                return Constants.E_NOINTERFACE;
            }
            #endregion
        }
     }
    [ComVisible(true)]
    [Guid("01AFBFE2-CA97-4F72-A0BF-E157038E4118")]
    public class NewWindowManager : INewWindowManager
    {
        public int EvaluateNewWindow(string pszUrl, string pszName,
            string pszUrlContext, string pszFeatures, bool fReplace, uint dwFlags, uint dwUserActionTime)
        {
            // use E_FAIL to be the same as CoInternetSetFeatureEnabled with FEATURE_WEBOC_POPUPMANAGEMENT
            int hr = MyBrowser.Constants.E_FAIL; 
            hr = MyBrowser.Constants.S_FALSE; //Block
            hr = MyBrowser.Constants.S_OK; //Allow all
            return hr;
        }
    }
