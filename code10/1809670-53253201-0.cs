    void BrowserDocumentCompleted(object sender,
        WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            string Tesla = "";
            var sal = (sender as WebBrowser).Document.GetElementsByTagName("div");
            foreach (HtmlElement link in sal)
            {
                if (link.GetAttribute("className") == "D(ib) Mend(20px)")
                {
                    Tesla = link.FirstChild.InnerHtml;
                }
            }
            label1.Text = Tesla;
        }
