    for (int i = 0; i < dt.Rows.Count; i++)
    {
        for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
        {
            Console.Write(dt.Rows[i].ItemArray[j] + ",");
        }
        Console.WriteLine();
    }
