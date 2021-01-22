    private void WebBrowser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
    {
        mshtml.IHTMLDocument2 doc2 = WebBrowser.Document.DomDocument;
        string ReplacementTag = "<span style='background-color: rgb(255, 255, 0);'>";
        StringBuilder strBuilder = new StringBuilder(doc2.body.outerHTML);
        string HTMLString = strBuilder.ToString();
        if (this.m_NoteType == ExtractionNoteType.SearchResult)
        {
            List<string> SearchWords = new List<string>();
            SearchWords.AddRange(this.txtNoteSearch.Text.Trim.Split(" "));
            foreach (string item in SearchWords)
            {
                int index = HTMLString.IndexOf(item, 0, StringComparison.InvariantCultureIgnoreCase);
                // 'If index > 0 Then
                while ((index > 0 && index < HTMLString.Length))
                {
                    HTMLString = HTMLString.Insert(index, ReplacementTag);
                    HTMLString = HTMLString.Insert(index + item.Length + ReplacementTag.Length, "</span>");
                    index = HTMLString.IndexOf(item, index + item.Length + ReplacementTag.Length + 7, StringComparison.InvariantCultureIgnoreCase);
                }
            }
        }
        else
        {
        }
        doc2.body.innerHTML = HTMLString;
    }
