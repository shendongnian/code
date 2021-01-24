    var client = new HttpClient();
    var response = await client.GetAsync(@"https://localhost:..."); ;
    var bytes = await response.Content.ReadAsByteArrayAsync();
    var fileName = response.Content.Headers.ContentDisposition.FileName;
    using (var stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write)) {
        await stream.WriteAsync(bytes, 0, bytes.Length);
    }
