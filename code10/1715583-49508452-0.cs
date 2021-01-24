    foreach (DataRow row in csvData.Rows)
    {
        double myDec;
        if (double.TryParse(row[colname], out myDec))
        {
            if (myDec >= med1 && myDec <= med2)
            {
                al.Add(myDec);                      
            }
        }
    }
