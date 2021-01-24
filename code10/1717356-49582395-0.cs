    string line = "";
    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
    StreamReader sr = new StreamReader(fs);
    StreamWriter sw = new StreamWriter(fs);
    List<string> lines = new List<string>();
    while ((line = sr.ReadLine()) != null)
    {
        line = "*" + line; //Do your processing
        lines.Add(line);
    }
    fs.SetLength(0);
    foreach (var newline in lines)
    {
        sw.WriteLine(newline);
    }
    sw.Flush();
    fs.Close();
