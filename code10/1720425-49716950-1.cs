    WebClient wc = new WebClient();
    byte[] bytes = wc.DownloadData(Stan.listaStanova[j].linkSlike);
    MemoryStream ms = new MemoryStream(bytes);
    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
    ms.Dispose();
