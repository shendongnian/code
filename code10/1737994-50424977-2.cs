    public void View(string guid) {
        var stream = null as Stream;
        repo.GetFileStream(fileName, filePath, out stream);
        if (stream.CanSeek) {
            stream.Seek(0, SeekOrigin.Begin);
        }
        var response = _ctx.reqObj.HttpContext.Response;
        response.ContentType = "application/pdf";
        response.Headers.Add("Content-Disposition", $"inline; filename={filename}");
        response.Headers.Add("Content-Length", stream.Length.ToString());
        response.Body = stream;
    }
