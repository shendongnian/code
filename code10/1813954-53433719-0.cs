    for (int i = 0 ; i < ReadData.Length; i++)
    {
        DateTime dtDateValue;
        if (DateTime.TryParse(ReadData[i][0], out dtDateValue))     
        {
            int[] iValuesToAdd = ConvertArrayToInt(ReadData[i]);
            if (dtDateValue.Date == DateTime.Now.Date)                   
            {
                for (int j = 0; j < iValuesToAdd.Length; j++)
                {
                    //Add the ReadData value variables here      
                }
            }
            else if (dtDateValue.Date != DateTime.Now.Date)                              
            {
                goto Endloop;                                   
            }
        }
    }
    Endloop:
    return ReadData;
