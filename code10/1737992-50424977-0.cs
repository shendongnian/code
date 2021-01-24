    public void View(string guid) {
        var stream = null as Stream;
        repo.GetFileStream(fileName, filePath, out stream);
        if (stream.CanSeek) {
            stream.Seek(0, SeekOrigin.Begin);
        }
        _ctx.reqObj.HttpContext.Response.ContentType = "application/pdf";
        _ctx.reqObj.HttpContext.Response.Headers.Add("Content-Disposition", "inline; filename=" + fileName);
        _ctx.reqObj.HttpContext.Response.Headers.Add("Content-Length", stream.Length);
        _ctx.reqObj.HttpContext.Response.Body = stream;
    }
