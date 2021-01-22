    public System.Drawing.Bitmap HTMLToImage(String strHTML)
    {
        System.Drawing.Bitmap myBitmap = null;
        System.Threading.Thread myThread = new System.Threading.Thread(delegate()
        {
            // create a hidden web browser, which will navigate to the page
            System.Windows.Forms.WebBrowser myWebBrowser = new System.Windows.Forms.WebBrowser();
            // we don't want scrollbars on our image
            myWebBrowser.ScrollBarsEnabled = false;
            // don't let any errors shine through
            myWebBrowser.ScriptErrorsSuppressed = true;
            // let's load up that page!    
            myWebBrowser.Navigate("about:blank");
            // wait until the page is fully loaded
            while (myWebBrowser.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
                System.Windows.Forms.Application.DoEvents();
                
            myWebBrowser.Document.Body.InnerHtml = strHTML;
            // set the size of our web browser to be the same size as the page
            int intScrollPadding = 20;
            int intDocumentWidth = myWebBrowser.Document.Body.ScrollRectangle.Width + intScrollPadding;
            int intDocumentHeight = myWebBrowser.Document.Body.ScrollRectangle.Height + intScrollPadding;
            myWebBrowser.Width = intDocumentWidth;
            myWebBrowser.Height = intDocumentHeight;
            // a bitmap that we will draw to
            myBitmap = new System.Drawing.Bitmap(intDocumentWidth - intScrollPadding, intDocumentHeight - intScrollPadding);
            // draw the web browser to the bitmap
            myWebBrowser.DrawToBitmap(myBitmap, new System.Drawing.Rectangle(0, 0, intDocumentWidth - intScrollPadding, intDocumentHeight - intScrollPadding));
        });
        myThread.SetApartmentState(System.Threading.ApartmentState.STA);
        myThread.Start();
        myThread.Join();
        return myBitmap;
    }
