    public IEnumerable<string> DownloadLines(string URL)
    {
        using (var request = WebRequest.Create(URL))
        using (var response = request.GetResponse())
        using (var str = response.GetResponseStream())
        using (var rdr = new StreamReader(str))
        {
            string line;
            while ( (line = rdr.ReadLine()) != null)
            {
                // make sure we yield a *different* variable (defined in the loop) each time
                var result = line;
                yield return result;
            }
        }
    }
