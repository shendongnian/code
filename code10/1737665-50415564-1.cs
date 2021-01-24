    var cd = new System.Net.Mime.ContentDisposition
    {
        FileName = "somepdf.pdf",
        Inline = true
    };
    Response.Headers.Add("Content-Disposition", cd.ToString());
       
    return File(bytes, "application/pdf");
