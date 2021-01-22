    using (var dr = ExecuteReader(databaseCommand))
    {
        int? outInt;
        string outString;
        Utility.ResetSchemaTable(dr, false);        
        while (dr.Read())
        {
            Utility.GetValueByParameter(dr, "SomeColumn", out outInt);
            if (outInt.HasValue) myIntField = outInt.Value;
        }
        Utility.ResetSchemaTable(dr, true);
        while (dr.Read())
        {
            Utility.GetValueByParameter(dr, "AnotherColumn", out outString);
            if (!string.IsNullOrEmpty(outString)) myIntField = outString;
        }
    }
