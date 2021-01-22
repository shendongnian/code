    private delegate void MyFunctionCaller();
    private static void DownloadMap(ParamForDownload p) 
    {
        WebClient client = new WebClient();
       client.DownloadFile(p.Url, p.LocalFile);
        DownloadMapComplete(p);
    }
    private void DownloadMapComplete(ParamForDownload p)
    {
    if (InvokeRequired == true)
      {
      MyFunctionCaller InvokeCall = delegate { DownloadMapComplete(p); };
      Invoke(InvokeCall);
      }
    else
      {
      pictureBox2.Picture = p.LocalFile;
      }
    }
