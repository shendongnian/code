    foreach (DataRow r in dt.Rows)
    {
        foreach (DataColumn c in dt.Columns)
        {
            if (c.ReadOnly)
                continue;
            if ($"{r[c]}" == "A") // if($"{r[c]}".Contains("A"))
                r[c] = "150";     //     r[c] = $"{r[c]}".Replace("A", "150");
            else if ($"{r[c]}" == "D")
                r[c] = "250";
        }
    }
