        private void webBrowser1_DocumentCompleted(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            var txt = searchTextBox.Text;
            if (!string.IsNullOrEmpty(txt))
                webBrowser1.Document.InvokeScript("highlight",
                    new object[] { txt });
        }
