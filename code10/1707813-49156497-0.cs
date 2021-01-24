    ...
        string line;
        bool first = true;
        while ((line = streamReader.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(line))
                if (!first)
                    streamWriter.WriteLine();
                streamWriter.Write(line);
                first = false;
        }
    ...
