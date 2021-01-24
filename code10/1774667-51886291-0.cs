    private string CreateDefaultFile()
    {
        using (var stream = Shelter.Assembly.GetManifestResourceStream($@"Mod.Resources.Config.{_file}"))
        {
            if (stream == null)
                throw new NullReferenceException(); //TODO
            using (var ms = new MemoryStream())
            {
                using (var fs = File.Open(Shelter.ModDirectory + _file, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    byte[] buffer = new byte[512];
    
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                        fs.Write(buffer, 0, bytesRead);
                    }
    
                    fs.Flush();
                    ms.Flush();
    
                    byte[] content = ms.ToArray();
                    if (content.Length >= 3 && content[0] == 0xEF && content[1] == 0xBB && content[2] == 0xBF)
                        return Encoding.UTF8.GetString(content, 3, content.Length - 3);
                    return Encoding.UTF8.GetString(content);
                }
            }
        }
    }
