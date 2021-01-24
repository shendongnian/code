    List<double> convertedPositions = new List<double>();
    List<double> convertedPlayers = new List<double>();
    
    foreach (string element in fractionedList)
    {
        var elements = element.Split(',');
    
        convertedPositions.AddRange(elements.Skip(2).Take(3).Select(x=> Convert.ToDouble(x)));
        convertedPositions.AddRange(elements.Skip(5).Take(3).Select(x => Convert.ToDouble(x));
    }
