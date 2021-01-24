    var myList = GetSpecificColumnValuesFromDatatableToList<decimal, string>(mydt, "colname", v => c.ToString("0.##"));
    public List<TResult> GetSpecificColumnValuesFromDatatableToList<T, TResult>(DataTable datatable, string colName, Func<T, TResult> converter)
    {
         return datatable.AsEnumerable().Select(r => converter(r.Field<T>(colName))).ToList();          
    }
