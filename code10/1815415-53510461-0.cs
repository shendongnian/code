        var obj = dt1.Rows
            .Cast<DataRow>()
            .GroupBy(row => (int)row["ID"])
            .ToDictionary(g => g.Key,
                          g => g.ToDictionary(row => (int)row["F_SD"],
                                              row => new { value = (decimal)row["VAL"] }));
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return Content(json, "application/json");
