    string result = "pass";
    for (i = 0; i < baseline.GetLength(0); i++)
        for (j = 0; j < baseline.GetLength(1); j++)
            {
               if (baseline[i, j]?.ToString() != result_PriceUpdate[i, j]?.ToString()) 
               {
                   result = "fail";
                   i = int.MaxValue;
                   j = int.MaxValue;
               }
            }
    result_file.WriteResultToExcel("Result Summary", 2, 2, result);
