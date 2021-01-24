    public void prepareData()
    {
        // use array of lists of YValues
        var tempbuffer = new List<double>[240];
        // initialize it
        for (int i = 0; i < tempbuffer.Length; i++)
        {
            tempbuffer[i] = new List<double>(); //set capacity for better performance
        }
        var timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        var oldest = timestamp - 240 + 1;
        // fill tempbuffer with existing DataPoint's YValues
        for (int i = 0; i < file.Length; i++)
        {
            if (file[i].XValue <= timestamp && file[i].XValue > timestamp - 240)
            {
                tempbuffer[file[i].XValue - oldest].Add(file[i].YValues);
            }
        }
        // get result
        var result = new DataPoint[tempbuffer.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new DataPoint(oldest + i, tempbuffer[i].Count == 0 ? 0 : tempbuffer[i].Average());
        }
    }
