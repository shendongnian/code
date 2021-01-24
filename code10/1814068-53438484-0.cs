    foreach (string line in lines)
    {
        string newLine = line.Replace(word, "");
        far.WriteLine(newLine);
    }
