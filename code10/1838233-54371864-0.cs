    private List<string> listOfLableValues = new List<string>();
    
    //... other WPF code
    // loop through all charts and to create them
    	   SeriesCollection = new SeriesCollection
    	   {
    			new StepLineSeries
    			{
    				Values = listOfChartValues[i],
                    PointGeometry = null,
    				// Fill = Brushes.Transparent
                 },
           };
    //... other Livecharts code
    
    		int lableCount = 1;
    		for (int i = 0; i < listOfChartValues.Count; i++)
    		{
    			listOfChartValues[i].AddRange(de.ListOfListPlottedAmpData[i]);
    
    
    			if (0 == i % (listOfChartValues[i].Count / 30))
    				listOfLableValues.Add(lableCount++.ToString());
    			else
    				listOfLableValues.Add("");
    		}
