    IList<double[]> result = new List<double[]>(); /list declaration
    // result gets value from a soap call 
    for (int i = 0; i < result.Count; i++)
    {
        for (int j = i + 1; j < result.Count; j++)
        {
             if (result[i][0].ToString() == result[j][0].ToString() && result[i][1].ToString() == result[j][1].ToString())
             {
                 result.Remove(result[j]);
                 j--;
             }
        }
    }  
