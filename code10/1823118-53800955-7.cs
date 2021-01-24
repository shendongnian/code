    foreach (DataRow r in dt.Rows)
    {
        var a = r.ItemArray;
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            if ($"{a[i]}" == "A") // if($"{a[i]}".Contains("A"))
                a[i] = "150";     //     a[i] = $"{a[i]}".Replace("A", "150");
            if ($"{a[i]}" == "D")
                a[i] = "250";
        }
        r.ItemArray = a;
    };
