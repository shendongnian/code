    System.Windows.Forms.WebBrowser objWebBrowser = new System.Windows.Forms.WebBrowser();
    objWebBrowser.Navigate(new Uri("your url of html document"));
    System.Windows.Forms.HtmlDocument objDoc = objWebBrowser.Document;
    System.Windows.Forms.HtmlElementCollection aColl = objDoc.All.GetElementsByName("IMG");
    ...
