    private async void btnSort_Click(object sender, EventArgs e)
    {
    	lblStatusUpdate.Text = @"Sorting...";
    	await Run();
    
    }
    
    
    public async Task Run()
    {
        //This line runs asynchronously and keeps the UI responsive.
    	await bubbleSort(iArray);
        
        //The remaining code runs on the UI thread
    	foreach (int item in iArray)
    	{
    		lbxNumbers.Items.Add(item);
    	}
    }
    
    
    public async Task bubbleSort(int[] iArray)
    {
    	await Task.Run(() =>
    	{
    		bool isSorted = false;
    		while (!isSorted)
    		{
    			isSorted = true; //You were missing this to break out of the loop.
    			for (int i = 0; i < iArray.Length - 1; i++)
    			{
    				if (iArray[i] > iArray[i + 1])
    				{
    					swap(iArray, i, i + 1);
    					isSorted = false;
    
    				}
    
    			}
    		}
    
    	});
    }
