    public static class WebViewExtension
    {
        public static HtmlAgilityPack.HtmlDocument GetHtmlDocument(this WebBrowser wView)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(wView.Document.Body.OuterHtml);
            return doc;
        }
        public static async Task<HtmlAgilityPack.HtmlDocument> LoadSiteAndGetHtml(this WebBrowser wView, string siteurl)
        {
            await wView.NavigateAndWait(siteurl);
            HtmlAgilityPack.HtmlDocument doc = wView.GetHtmlDocument();
            return doc;
        }
        public static async Task NavigateAndWait(this WebBrowser wView, string siteurl)
        {
            TaskCompletionSource<bool> loaded = new TaskCompletionSource<bool>();
            wView.Navigate(new Uri(siteurl));
            wView.DocumentCompleted += delegate (object sender, WebBrowserDocumentCompletedEventArgs args)
            {
                loaded?.TrySetResult(true);
            };
            //wait until the website is loaded
            await loaded.Task;
        }
    }
