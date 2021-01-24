    var myList = GetSpecificColumnValuesFromDatatableToList<decimal, string>(mydt, "colname", v => c.ToString("0.##"));
    public List<TResult> GetSpecificColumnValuesFromDatatableToList<TColumn, TResult>(DataTable datatable, string colName, Func<TColumn, TResult> converter)
    {
         return datatable.AsEnumerable().Select(r => converter(r.Field<TColumn>(colName))).ToList();          
    }
