    foreach(string sFileline in sFileLines)
    {
      string[] rowarray = sFileline.Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
        smartdata[i]=new string[rowarray.Length];
        for (int j = 0; j < rowarray.Length; j++)
        {
            smartdata[i][j] =rowarray[j]; //where the error occurs
            //Debug.Log(smartdata[i][j]);
        }
        i = i + 1 ;
    }
