    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream);
    // Write Your data here in writer
    writer.Write("Hello, World!");
    writer.Flush();
    stream.Position = 0;
    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    result.Content = new StreamContent(stream);
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
    return result;
