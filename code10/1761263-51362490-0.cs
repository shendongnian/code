    using (var fileStream = File.OpenRead("somePath"))
    {
        using (var reader = XmlReader.Create(fileStream))
        {
            while (reader.Read())
            {
                Console.WriteLine($"Now at position: {fileStream.Position}");
            }
        }
    }
