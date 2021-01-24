    if (dt.Rows.Count > 0 && dt.AsEnumerable().Select(x => x["Empolyee_CRC"]).Count() > 0)
    {
        var result = dt.AsEnumerable()
                       .GroupBy(g => g["Empolyee_CRC"])
                       .Where(c => c.Count() > 1)
                       .OrderBy(x => x.Key)
                       .Select(g => new { Empolyee_CRC = g.FirstOrDefault().Field<string>("Empolyee_CRC") })
                       .ToList();
    }
    
