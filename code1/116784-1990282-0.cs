static void DownloadCompleted(HttpConnection conn) {
        Image img;
        HtmlDocument doc;
        bool bText = false;
        using (System.IO.BinaryReader br = new BinaryReader(conn.Stream)){
            char[] chPeek = br.ReadChars(30);
            string s = chPeek.ToString().Replace(" ", "");
            if (s.IndexOf("&lt;DOC") &gt; 0 || s.IndexOf("&lt;HTML") &gt; 0){
                // We have a pure Text!
                bText = true;
            }
        }
        if (bText){
            doc = new HtmlDocument();
            doc.Load(conn.Stream);
        }else{
            img = Image.FromStream(conn.Stream);
        }
}
