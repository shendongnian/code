    static void DownloadCompleted(HttpConnection conn)
    {
        Image img = LoadImage(conn);
        if(img != null)
        {
             ProcessImage(img);
             return;
        }
        HtmlDocument doc = LoadDocument(conn);
        if(doc != null)
        {
             ProcessDocument(doc)
             return;
        }
        return;
    }
