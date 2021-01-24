    static long CountLinesInFile(string fileName)
    {
    
    	var lines = File.ReadAllLines(fileName);
    	using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"F:\Work\FLP Code\r\g.txt", true))
        {
                file.WriteLine($"AFP|QTY{Environment.NewLine}DDD|{lines.Length-1}");
        }
    	return lines.Length-1;
    }
