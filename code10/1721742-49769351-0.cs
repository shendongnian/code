    var pic = System.Web.HttpContext.Current.Request.Files["ImagePath"];
    byte[] bytes;
    using (var stream = new MemoryStream())
    {
       pic.InputStream.CopyTo(stream);
       bytes = stream.ToArray();
    }
