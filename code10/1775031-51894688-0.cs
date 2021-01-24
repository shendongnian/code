    [HttpPost]
    public IHttpActionResult Post(ImageDTO request)
    {
        var buffer = Convert.FromBase64String(request.Image);
        HttpPostedFileBase objFile = (HttpPostedFileBase)new MemoryPostedFile(buffer);
    
        // full virtual path of the image name
        // TODO: right now, request.Name is assumed to be the image file name
        var virtualPath = string.Format("/api/Images/{0}.jpg", request.Name);
        using( var content = new MultipartFormDataContent())
        {
            // **** I am NOT sure what is the purpose of bytes/fileContent here ****
            byte[] bytes = new byte[objFile.InputStream.Length + 1];
            objFile.InputStream.Read(bytes, 0, bytes.Length);
            var fileContent = new ByteArrayContent(bytes);
            fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = request.Name };
            content.Add(fileContent);
            // here we are converting the virtual path to physical path
            var physicalPath = Server.MapPath(virtualPath);
            objFile.SaveAs(physicalPath);
        }
        // I guess here you want to return the newly created path for the image
        return Ok(virtualPath);
    }
