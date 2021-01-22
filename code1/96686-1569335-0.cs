        private void setText(string htmlText)
        {
                webBrowser1.DocumentText = htmlText;
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            label1.Text = webBrowser1.DocumentText;
        }
