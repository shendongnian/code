    public static string stopWriteFileHalfWay(string option)
    {
        string tempPath = Path.GetTempFileName();
        using (StreamWriter sw = File.AppendText(tempPath))
        {
            sw.WriteLine("line 1");               
            return "after line 3"; // => exit and do not want to create and write any file
            sw.WriteLine("line 2");
        }
        
        File.Move(tempPath, @"d:\test\test.txt");
        return "completed";
    }
