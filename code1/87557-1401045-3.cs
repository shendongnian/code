    System.Net.WebClient we = new System.Net.WebClient();
    try
    {
        we.DownloadFile("", "");
    }
    catch (System.Net.WebException wex)
    {
        //failed!
    }
