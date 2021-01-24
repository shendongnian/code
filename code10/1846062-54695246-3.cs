    const string FilePath = @"D:\Aggregate_Minute_AAPL.txt";
    
    class SomeClass
    {
    	public string Sym { get; set; }
    	public string Other { get; set; }
    }
    
    private void Something() {
    	File
    		.ReadLines(FilePath)
    		.AsParallel()
    		.Select(x => x.TrimStart('[').TrimEnd(']'))
    		.Select(JsonConvert.DeserializeObject<List<SomeClass>>)
    		.ForAll(WriteRecord);
    }
    
    private const string DirPath = @"D:\COMB1\MinuteAggregates";
    private const string Separator = @",";
    
    private void WriteRecord(List<SomeClass> data)
    {
    	foreach (var item in data)
    	{
    		var fileNames = Directory
    			.GetFiles(DirPath, item.Sym+"_*.txt", SearchOption.AllDirectories);
    		foreach (var fileName in fileNames)
    		{
    			var fileLines = File.ReadAllLines(fileName)
    				.Skip(1).ToList();
    			var lastLine = fileLines.Last();
    			if (!lastLine.Contains(item.Sym))
    			{
    				fileLines.RemoveAt(fileLines.Count - 1);
    			}
    			fileLines.Add(
    				new StringBuilder()
    					.Append(item.Sym)
    					.Append(Separator)
    					.Append(item.Other)
    					.Append(Environment.NewLine)
    					.ToString()
    			);
    			File.WriteAllLines(fileName, fileLines);
    		}
    	}
    }
