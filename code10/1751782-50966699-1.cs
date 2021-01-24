    string result = webClient.DownloadString(url);
    if (result.Contains("windows-1251"))
    {
      webClient.Encoding = System.Text.Encoding.GetEncoding("windows-1251");
      result = webClient.DownloadString(url);
    }
    else if (result.Contains("ISO-8859-2"))
    {
      webClient.Encoding = System.Text.Encoding.GetEncoding("ISO-8859-2");
      result = webClient.DownloadString(url);
    }
