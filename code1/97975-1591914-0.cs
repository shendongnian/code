    foreach (string filename in 
        Directory.GetFiles(
            Server.MapPath("/"), "*.jpg", 
            SearchOption.AllDirectories))
    {
        Response.Write(
            String.Format("{0}<br />", 
                Server.HtmlEncode(filename)));
    }
