    private async void Button_Click(object sender, RoutedEventArgs e)
    {
    	//dir contents
    	var files = new string[4] { "file1", "file2", "file3", "file4" };
    	//progress bar for each file
    	Pg.Value = 0;
    	Pg.Maximum = files.Length;
    	foreach(var file in files)
    	{                
    		await ProcessOneFile(file, entries => 
    		{
    			foreach(var entry in entries)
    			{
    				LogEntries.Add(entry);
    			}
    		});
    		Pg.Value++;
    	}
    }
    
    public async Task ProcessOneFile(string fileName, Action<List<string>> onEntryBatch)
    {
    	//Get the lines
    	var lines = await Task.Run(() => GetRandom());
    	//the max amount of lines you want to update at once
    	var batchBuffer = new List<string>(100);
    	
    	//Process lines
    	foreach (string line in lines)
    	{
    		//Create the line
    		if (CreateLogLine(line, out object logLine))
    		{
    			//do your check
    			if (logLine != null)
    			{
    				//add
    				batchBuffer.Add($"{fileName} -{logLine.ToString()}");
    				//check if we need to flush
    				if (batchBuffer.Count != batchBuffer.Capacity)
    					continue;
    				//update\flush
    				onEntryBatch(batchBuffer);
    				//clear 
    				batchBuffer.Clear();
    			}
    		}
    	}
    
    	//One last flush
    	if(batchBuffer.Count > 0)
    		onEntryBatch(batchBuffer);            
    }
