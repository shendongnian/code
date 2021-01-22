    public void CreateTextFormats(DataObject do) {
        string textVersion;
        string htmlVersion;
        // Do the work of making the tab-separated text version and the HTML code
        do.SetData(textVersion);
        do.SetText(ConvertToHtmlFragment(htmlVersion), TextDataFormat.Html);
    }
