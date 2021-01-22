    var lines = File.ReadAllLines(filePath);
    foreach (change to make)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            // read values from line
            if (need_to_modify)
            {
                // whatever change logic you want here.
                lines[i] = lines[i].Replace(...);
            }
        }
    }
    File.WriteAllLines(filePath, lines);
