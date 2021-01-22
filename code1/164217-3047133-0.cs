    var splitValues = new List<double?>(); 
    splitValues.Add(Math.Round(assetSplit.EquityTypeSplit() ?? 0)); 
    splitValues.Add(Math.Round(assetSplit.PropertyTypeSplit() ?? 0)); 
    splitValues.Add(Math.Round(assetSplit.FixedInterestTypeSplit() ?? 0)); 
    splitValues.Add(Math.Round(assetSplit.CashTypeSplit() ?? 0)); 
     
    var listSum = splitValues.Sum();
    while (listSum != 100) 
    { 
        int increment = listSum > 100 ? -1 : 1;
        var value = listSum > 100 ? splitValues.Max() : splitValues.Min();
        splivValue[splitValues.IndexOf(value)] += increment;
        listSum += increment;
    }
