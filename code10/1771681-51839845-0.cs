    public static IEnumerable<string[]> RowValueCollection()
    {
        var result = Data.Tables[0].Rows.OfType<DataRow>()
            .Select(dr => dr.ItemArray.Select(ia => ia.ToString()).ToArray());
        return result;
    }
