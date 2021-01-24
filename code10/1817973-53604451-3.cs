    static long CountLinesInFile(string fileName,string outputFileName)
    {
        var lines = File.ReadAllLines(fileName);
    	using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFileName, true))
        {
                file.WriteLine($"AFP|QTY{Environment.NewLine}DDD|{lines.Length-1}");
        }
    	return lines.Length-1;
    }
