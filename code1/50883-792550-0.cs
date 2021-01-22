    List<string> filesUploaded = new List<string>();
    foreach (HttpPostedFile file in HttpContext.Current.Request.Files)
    {
        if (file.ContentLength <= 0)
            continue;
    
        string filename = String.Format("{0}.jpg",Regex.Replace(Guid.NewGuid().ToString(), "[^A-Za-z0-9]*", String.Empty));
        file.SaveAs(Path.Combine(Server.MapPath("/upload/temp/"), filename));
        filesUploaded.Add(filename);
    }
    Response.Write(String.Format("<{0}>window.opener.FilesUploaded([{1}]);</{0}>","script", String.Join(",",filesUploaded.ToArray()).TrimEnd(new char[]{','})));
