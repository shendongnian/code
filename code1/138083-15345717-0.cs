        string debug1 = readIn.Rows[i].ItemArray[numColumnToCopyTo].ToString();
        string debug2 = readIn.Rows[i].ItemArray[numColumnToCopyTo].ToString().Trim();
        string debug3 = readIn.Rows[i].ItemArray[numColumnToCopyFrom].ToString().Trim();
        string towrite = debug2 + ", " + debug3;
        readIn.Rows[i].SetField<string>(numColumnToCopyTo,towrite); 
    
        readIn.AcceptChanges();
