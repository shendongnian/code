    [HttpPost]
    [Route("..."]
    public void ReceiveFile()
    {
         System.Web.HttpPostedFile file = HttpContext.Current.Request.Files["keyName"];
         System.IO.MemoryStream mem = new System.IO.MemoryStream();
         file.InputStream.CopyTo(mem);
         byte[] data = mem.ToArray();
         // you can replace the MemoryStream with file.saveAs("path") if you want.
    }
