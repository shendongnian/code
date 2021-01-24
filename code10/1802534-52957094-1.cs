    static void Main(string[] args)
    {
    	string src = @"C:\temp\Score_4.dat";
    	List<string> dataFromFile = new List<string>();
    	using (var sr = new StreamReader(src))
    	{
    		while (!sr.EndOfStream)
    		{
    			string thisLine = sr.ReadLine();
    			string[] parts = thisLine.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    			if (parts.Length == 3)
    			{
    				string jsonArray = "[" + string.Join(",", parts) + "]";
    				dataFromFile.Add(jsonArray);
    			}
    			else
    			{
    				/* the line did not have three entries */
    				/* Maybe keep a count of the lines processed to give an error message to the user */
    			}
    		}
    	}
    
    	/* Do something with the data... */
    	int totalEntries = dataFromFile.Count();
    	int maxBatchSize = 50;
    	int nBatches = (int)Math.Ceiling((double)totalEntries / maxBatchSize);
    	for(int i=0;i<nBatches;i+=1)
    	{
    		string thisBatchJsonArray = "{\"myData\":[" + string.Join(",", dataFromFile.Skip(i * maxBatchSize).Take(maxBatchSize)) + "]}";
    		Console.WriteLine(thisBatchJsonArray);
    	}
    
    	Console.ReadLine();
    }
