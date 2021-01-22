    string[] lines = File.ReadAllLines(fileName);
    string newLine = string.Empty;
    foreach (string line in lines)
    {
        string[] items = line.Split(myItemDelimiter);
        newLine = string.Format("{0},{1},{2}", items[1], items[0], items[2]);
        // Append to new file here...
    }
