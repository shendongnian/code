    using (var fileStream = File.OpenRead("somePath"))
    {
        using (var reader = XmlReader.Create(fileStream))
        {
            long lastPosition = 0;
            while (reader.Read())
            {
                if (lastPosition != fileStream.Position)
                {
                    lastPosition = fileStream.Position;
                    Console.WriteLine($"Read {lastPosition} from {fileStream.Length} ({100.0 * lastPosition / fileStream.Length}%)");
                }
            }
        }
    }
