    var splitValues = new List<double?>();
    splitValues.Add(Math.Round(assetSplit.EquityTypeSplit() ?? 0));
    splitValues.Add(Math.Round(assetSplit.PropertyTypeSplit() ?? 0));
    splitValues.Add(Math.Round(assetSplit.FixedInterestTypeSplit() ?? 0));
    splitValues.Add(Math.Round(assetSplit.CashTypeSplit() ?? 0));
    
    var listSum = splitValues.Sum(split => split.Value);
    while (listSum != 100)
    {
      var value = listSum > 100 ? splitValues.Max() : splitValues.Min();
      var idx = splitValues.IndexOf(value);
      splitValues.RemoveAt(idx);
      splitValues.Insert(idx, value + (listSum > 100 ? -1 : 1));
      listSum = splitValues.Sum(split => split.Value);
    }
