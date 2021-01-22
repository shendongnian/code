    using (HttpWebResponse response = (HttpWebResponse)objWebReq.GetResponse())
    {
        // Are you sure it's *really* ASCII, rather than (say) UTF-8?
        using (TextReader reader = new StreamReader(response.GetResponseStream(),
                                                    Encoding.ASCII))
        {
            return reader.ReadToEnd();
        }
    }
