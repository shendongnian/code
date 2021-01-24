    string MyNewFile = "...";
    using (StreamWriter sWriter = new StreamWriter(MyNewFile, false, encoding, 1))
    {
        foreach(string line in File.ReadLines(myFile))
        {
             sWriter.WriteLine(SpacesToDelimiter(line));
        }
    }
 
