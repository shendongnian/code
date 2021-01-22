    public static Dictionary<TKey, List<TValue>> ToGroupedDictionary<TKey, List<TValue>>(
        this DataTable input, 
        Func<TKey, DataRow> keyConverter, 
        Func<TValue, DataRow> valueConverter )
    {
        return input.Rows.
            //group by the key field
            GroupBy( keyConverter ).
            ToDictionary(
                grp => grp.Key,
                //convert the collection of rows into values
                grp => grp.Select( valueConverter ).ToList() );
    }
    //now you have a simpler syntax
    var dictOfLst = ds.Tables[0].ToGroupedDictionary(
        dr => dr.Field<string>("key"),
        dr => dr.Field<string>("value") );
        
