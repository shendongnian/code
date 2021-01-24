    foreach (DataRow row in csvData.Rows)
    {
        double myDec;
        if (row[colname] != null && double.TryParse(row[colname].Tostring(), out myDec))
        {
            if (myDec >= med1 && myDec <= med2)
            {
                al.Add(myDec);                      
            }
        }
    }
