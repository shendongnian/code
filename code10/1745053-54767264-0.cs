    var blob = container.GetBlockBlobReference(outputFilename);
    using (var stream = await blob.OpenWriteAsync())
    using (var zip = new ZipArchive(stream, ZipArchiveMode.Create))
    {
        for (int i = 0; i < 2000; i++)
        {
            using (var randomStream = CreateRandomStream(2))
            {
                var entry = zip.CreateEntry($"{i}.zip", CompressionLevel.Optimal);
                using (var innerFile = entry.Open())
                {
                    await randomStream.CopyToAsync(innerFile);
                }
            }
        }
    }
