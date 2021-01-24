    Request.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
    using (var sr = new System.IO.StreamReader(Request.InputStream))
    {
        string json = sr.ReadToEnd();
    }
