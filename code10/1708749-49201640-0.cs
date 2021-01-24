    // Set up the arrays of XlColumnDataTypes
    int[,] trimmedDataTypes = new int[trimmedTranlog.TagsPresent.Count, 2];
    for(int i = 1; i <= trimmedDataTypes.Length / 2; i++)
    {
        trimmedDataTypes[i - 1, 0] = i;
        trimmedDataTypes[i - 1, 1] = (int)Excel.XlColumnDataType.xlTextFormat;
    }
    int[,] fullDataTypes = new int[fullTranlog.TagsPresent.Count, 2];
    for(int i = 1; i <= fullDataTypes.Length / 2; i++)
    {
        fullDataTypes[i - 1, 0] = i;
        fullDataTypes[i - 1, 1] = (int)Excel.XlColumnDataType.xlTextFormat;
    }
