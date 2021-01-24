    var totalPageBreaks = 0;
    for (int j = 0; j <  < Input.Count; j++)
    {
        IRow row = sheet.CreateRow(j + 2);
        if (internalCounter == limit)
        {
            totalPageBreaks++;
            sheet.SetRowBreak(j + 1);
            internalCounter = 0;
        }
