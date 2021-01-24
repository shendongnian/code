    public static Dictionary<DateTime, int[]> CompareDateMethod(Dictionary<DateTime, int[]> oDateTimeAndIntDictionary,string[][] ReadData)
    {
        Dictionary<DateTime, int[]> oPrintRealData = new Dictionary<DateTime, int[]>();
        Dictionary<DateTime, int[]> oAddRealData = new Dictionary<DateTime, int[]>();
        for (int i = 0 ; i < ReadData.Length; i++)
        {
            DateTime dtDateValue;
            if (DateTime.TryParse(oDateTimeAndIntDictionary[0][0], out dtDateValue))     
            {
                int[] iValuesToAdd = ConvertArrayToInt(ReadData[i]);
                if (dtDateValue.Date == DateTime.Now.Date)                   
                {
                    for (int j = 0; j < iValuesToAdd.Length; j++)
                    {
                        //Add the ReadData values here and store at ReadData[i][j]
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
    }
