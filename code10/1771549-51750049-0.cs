    public static async Task Get(string filename)
    {
        string outputFile = "Export_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
    
        using (var outStream = File.Create(outputFile))
        {
            using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
            {
                var fileInArchive = archive.CreateEntry("test.txt", CompressionLevel.Optimal);
                using (var entryStream = fileInArchive.Open())
                using (var fileToCompressStream = File.Open(filename, FileMode.Open))
                {
                    // Skip the first 20 bytes
                    fileToCompressStream.Position = 20;
                    fileToCompressStream.CopyTo(entryStream);
                }
            }
        }
    }
