    HttpWebRequest req   = (HttpWebRequest)WebRequest.Create(URL);
    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
    Stream st            = resp.GetResponseStream();
    StreamReader sr      = new StreamReader(st);
    string buffer        = sr.ReadToEnd();
    int startPos, endPos;
    startPos = buffer.IndexOf("&lt;title>",
    StringComparison.CurrentCultureIgnoreCase) + 7;
    endPos = buffer.IndexOf("&lt;/title>",
    StringComparison.CurrentCultureIgnoreCase);
    string title = buffer.Substring(startPos, endPos - startPos);
    Console.WriteLine("Response code from {0}: {1}", s,
            resp.StatusCode);
    Console.WriteLine("Page title: {0}", title);
    sr.Close();
    st.Close();
