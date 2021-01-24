    //create generic lists
    List<DateTime> listDate = new List<DateTime>();										
    List<int> listSize = new List<int>();										
    List<string> listSign = new List<string>();										
    
    //fill lists with data from wherever
    for(int i = 0; i < dviewExport.RowCount; i++)										
    {										
    	if(listSign.Count == 0)								
    	{								
    		signCount = 1;							
    		listDate.Add((DateTime)dviewExport[0, i].Value);							
    		listSize.Add(1);							
    		listSign.Add((string)dviewExport[$"{Sign}", i].Value);						
    		continue;							
    	}								
    	if(listSign[listSign.Count - 1] == dviewExport[$"{Sign}", i].Value.ToString())								
    	{								
    		listSize[listSize.Count - 1] += 1;							
    		signCount++;							
    		if(maxCount < signCount)							
    			maxCount = signCount;						
    	}								
    	else								
    	{								
    		signCount = 1;							
    		listDate.Add((DateTime)dviewExport[0, i].Value);							
    		listSize.Add(1);							
    		listSign.Add((string)dviewExport[$"{Sign}", i].Value);							
    	}								
    }		
																
    //create two dimensional object lists with size of generic lists
    object[,] outDate = new object[listDate.Count, 1];										
    object[,] outSize = new object[listSize.Count, 1];										
    object[,] outSign = new object[listSign.Count, 1];										
   	
    //fill two dimensional object lists with data from generic lists
    for(int row = 0; row < listDate.Count; row++)
	{
        outDate[row, 0] = listDate[row];									
   	    outSize[row, 0] = listSize[row];									
   	    outSign[row, 0] = listSign[row];
	}							
    										
    //set Excel ranges and paste lists
    range = excelWsExport.get_Range($"B32:B{32 + listDate.Count}", Type.Missing);										
    range.NumberFormat = "d.MM.yyyy H:mm:ss";										
    range.Value = outDate;										
    										
    range = excelWsExport.get_Range($"C32:C{32 + listSize.Count}", Type.Missing);										
    range.Value = outSize;										
    										
    range = excelWsExport.get_Range($"D32:D{32 + listSign.Count}", Type.Missing);										
    range.Value = outSign;										
