    XLS.Excel.Range range = ws.UsedRange;
    object[,] values;
    if (range.Value2.GetType().IsArray)
    {
        values = (object[,])range.Value2;
    }
    else
    {
        values = new object[2,2];
        values[1,1] = range.Value2;
    }
