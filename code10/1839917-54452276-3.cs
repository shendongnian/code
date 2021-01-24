    string result = "pass";
    for (i = 1; i <= baseline.GetLength(0); i++)
        for (j = 1; j <= baseline.GetLength(1); j++)
            {
               if (baseline[i, j]?.ToString() != result_PriceUpdate[i, j]?.ToString()) 
               {
                   result = "fail";
                   i = int.MaxValue;
                   break;
               }
            }
    result_file.WriteResultToExcel("Result Summary", 2, 2, result);
