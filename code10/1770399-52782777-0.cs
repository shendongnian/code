    using (var stream = File.OpenRead("placeholder.pdf"))
    {
        var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
        {
            Headers = new HeaderDictionary(),
            ContentType = "application/pdf"
        };
    }
