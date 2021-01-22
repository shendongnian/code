    try
    {
        WebClient wc = new WebClient(); 
        wc.DownloadFile("ftp://ftp.website.com/sample.zip");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString()); // Or Debug.Trace, or whatever
        throw;    // As if the catch were not present
    }
