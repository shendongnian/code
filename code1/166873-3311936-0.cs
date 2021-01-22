    private void OnDocumentComplete(object frame, ref object urlObj)
    {
        System.Threading.ThreadPool.QueueUserWorkItem((o) =>
        {
            System.Threading.Thread.Sleep(1000);
                HTMLDocument document = (HTMLDocument)this.browser.Document;
                document.title = "Hello, StackOverflow!";
                IHTMLDOMNode greetings = document.createTextNode("Hi there!");
                IHTMLDOMNode body = document.body as IHTMLDOMNode;
                body.insertBefore(greetings, body.firstChild);                
        }, this.browser);
    }
    
    #region IObjectWithSite Members
    int IObjectWithSite.SetSite(object site)
    {
        if (site != null)
        {
            this.browser = (WebBrowser)site;
            this.browser.DocumentComplete +=
             new DWebBrowserEvents2_DocumentCompleteEventHandler(
              this.OnDocumentComplete);
        }
        else
        {
            if (this.browser != null)
            {
                this.browser.DocumentComplete -=
                 new DWebBrowserEvents2_DocumentCompleteEventHandler(
                  this.OnDocumentComplete);
                this.browser = null;
            }
        }
        return 0;
    }
    int IObjectWithSite.GetSite(ref Guid guid, out IntPtr ppvSite)
    {
        IntPtr punk = Marshal.GetIUnknownForObject(this.browser);
        int hr = Marshal.QueryInterface(punk, ref guid, out ppvSite);
        Marshal.Release(punk);
        return hr;
    }
    #endregion
