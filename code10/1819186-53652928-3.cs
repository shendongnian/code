        //test data
        Excel.Range rngString = ws.get_Range("B12", missing);        
        Excel.Range rngLeftValue = ws.get_Range("D14", missing);        
        Excel.Range rngValue = ws.get_Range("A15", missing);
        rngString.Value2 = "'test";
        rngLeftValue.Value2 = "'10";
        rngValue.Value2 = 10;
        //Is numeric?
        Double val;
        if (Double.TryParse(rngString.Value2.ToString(), out val))
        {
            System.Diagnostics.Debug.Print(val.ToString());
        }
        else //it's a string
        {
            string sString = rngString.Text.ToString();
            rngString.Clear();
            string sStringx = sString.Substring(0);
            rngString.Value2 = sStringx;
            System.Diagnostics.Debug.Print(rngString.Value2.ToString());
        }
        if (Double.TryParse(rngLeftValue.Value2.ToString(), out val))
        {
            System.Diagnostics.Debug.Print(val.ToString());
        }
        if (Double.TryParse(rngValue.Value2.ToString(), out val))
        {
            System.Diagnostics.Debug.Print(val.ToString());
        }
