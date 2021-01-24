    public void prepareData()
    {
        // it will be initialized with null values
        var tempbuffer = new DataPoint[240];
        var timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        var oldest = timestamp - 240 + 1;
        // fill tempbuffer with existing DataPoints
        for (int i = 0; i < file.Length; i++)
        {
            if (file[i].XValue <= timestamp && file[i].XValue > timestamp - 240)
            {
                tempbuffer[file[i].XValue - oldest] = new DataPoint(file[i].XValue, file[i].YValues);
            }
        }
        // fill null values in tempbuffer with 'empty' DataPoints
        for (int i = 0; i < tempbuffer.Length; i++)
        {
            tempbuffer[i] = tempbuffer[i] ?? new DataPoint(oldest + i, 0);
        }
    }
