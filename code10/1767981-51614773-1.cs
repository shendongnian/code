    int startIndex = 0;
    while (startIndex < dt.Rows.Count)
    {
        DateTime timeStart = DateTime.ParseExact(dt.Rows[startIndex][1].ToString(), "dd-MM-yy HH:mm",
            CultureInfo.InvariantCulture);
        DateTime timeEnd = timeStart;
        int lowestValue = int.Parse(dt.Rows[startIndex][3].ToString());
        int endIndex = startIndex;
        //loop to find end index of 5 minute loop
        for (int j = startIndex++; j < dt.Rows.Count; j++)
        {
            endIndex = j;
            timeEnd = DateTime.ParseExact(dt.Rows[endIndex][1].ToString(), "dd-MM-yy HH:mm",
                CultureInfo.InvariantCulture);
            if ((timeEnd - timeStart).TotalMinutes >= 5)
            {
                break;
            }
            int newValue = int.Parse(dt.Rows[endIndex][3].ToString());
            if (newValue < lowestValue)
            {
                lowestValue = newValue;
            }
        }
       
        
            dt.Rows[startIndex-1][11] = lowestValue.ToString();
        startIndex = endIndex;
        if (startIndex >= datatable.Rows.Count - 1)
                    break;
    }
