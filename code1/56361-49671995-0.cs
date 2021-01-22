    private static string WriteFileToDisk(byte[] data, string fileName, int version = 0)
    {
        try
        {
            var versionExtension = version > 0 ? $"_{version:000}" : string.Empty;
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}{versionExtension}.pdf");
            using (var writer = new FileStream(filePath, FileMode.Create))
            {
                writer.Write(data, 0, data.Length);
            }
            return filePath;
        }
        catch (IOException)
        {
            return WriteFileToDisk(data, fileName, ++version);
        }
    }
