    static long CountLinesInFile(string fileName)
    {
    	uint count = 0;
    	int query = (int)Convert.ToByte('\n');
    	using (var stream = File.OpenRead(fileName))
    	{
    	    int current;
    	    do
    	    {
    	        current = stream.ReadByte();
    	        if (current == query)
    	        {
    	            count++;
    	            continue;
    	        }
    	    } while (current!= -1);
    	}
    
    	using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"F:\Work\FLP Code\r\g.txt", true))
        {
                file.WriteLine($"AFP|QTY{Environment.NewLine}DDD|{count}");
        }
    	return count;
    }
