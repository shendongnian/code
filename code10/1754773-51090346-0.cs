    List<Object> longTermObjects = new List<object>();
    foreach (var tuple in dataPerTime)
    {
        List<Object> returnObjDataLine = new List<Object>();
        returnObjDataLine.Add(tuple.Item1);
        foreach (var line in PlotLines)
        {
            if (tuple.Item2.Equals(line.Key))
            {
                returnObjDataLine.Add(tuple.Item3);
            }
            else
            {
                returnObjDataLine.Add(null);
            }
        }
        longTermObjects.Add(returnObjDataLine);
    }
