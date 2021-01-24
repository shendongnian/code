    var i = 1;
    using (var outStream = new MemoryStream())
    {
        using (var archive = new ZipFile())
        {
            foreach (var item in byteArrays)
            {
                using (MemoryStream ms = new MemoryStream(item))
                {
                    var entry = archive.AddEntry($"file{i++}.pdf", ms);
                    archive.Save(outStream);
                }
            }
        }
        outStream.Position = 0;
        return File(outStream.ToArray(), "application/zip", "all.zip");
    }
