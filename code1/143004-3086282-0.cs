    private const string CSS_960 = @"960.css";
    private const string SCRIPT_FMT = @"<style TYPE=""text/css"">{0}</style>";
    private const string HEADER_END = @"</head>";
     public void SetDocumentText(string value)
    {
        this.Url = null;  // can't have both URL and DocText
        this.Navigate("About:blank");
        string css = null;
        string html = value;
        // check for known CSS file links and inject the resourced versions
        if(html.Contains(CSS_960))
        {
          css = GetEmbeddedResourceString(CSS_960);
          html = html.Insert(html.IndexOf(HEADER_END), string.Format(SCRIPT_FMT,css));
        }
        
        if (Document != null) { 
          Document.Write(string.Empty);
        }
        DocumentText = html;
    }
