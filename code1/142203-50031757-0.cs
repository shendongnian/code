    System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
    {
       FileName = Uri.EscapeUriString(fileName),
       Inline = true  // false = prompt the user for downloading;  true = browser to try to show the file inline
    };
    Response.Headers.Add("Content-Disposition", cd.ToString());
