    string path = Server.MapPath(your application path);
    WebClient client = new WebClient();            
    byte[] data = client.DownloadData(new Uri(path));
    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}", "aspnet.pdf"));
    Response.OutputStream.Write(data, 0, data.Length);
    try this code.. its helpful
