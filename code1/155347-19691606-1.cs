    File.AppendAllLines(
        "FileAppendAllLines.txt", 
        new string[] { "line1", "line2", "line3" });
    
    File.AppendAllText(
        "FileAppendAllText.txt",
        "line1" + Environment.NewLine +
        "line2" + Environment.NewLine +
        "line3" + Environment.NewLine);
    
    using (StreamWriter stream = File.AppendText("FileAppendText.txt"))
    {
        stream.WriteLine("line1");
        stream.WriteLine("line2");
        stream.WriteLine("line3");
    }
    
    using (StreamWriter stream = new StreamWriter("StreamWriter.txt", true))
    {
        stream.WriteLine("line1");
        stream.WriteLine("line2");
        stream.WriteLine("line3");
    }
    
    using (StreamWriter stream = new FileInfo("FileInfo.txt").AppendText())
    {
        stream.WriteLine("line1");
        stream.WriteLine("line2");
        stream.WriteLine("line3");
    }
