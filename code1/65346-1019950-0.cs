    Dictionary <TimeSeries, Dictionary<DateTime, Value>> dict = new Dictionary<TimeSeries, Dictionary<DateTime, Value>>();
    
    foreach (TimeSeries series in dict.Keys) {
        //table row output code goes here
        Dictionary<DateTime, Value> innerDict = dict[series];
        foreach (DateTime date in innerDict.Keys) {
            Value seriesValueAtTimeT = innerDict[date];
            //table column output code goes here
        }
    }
