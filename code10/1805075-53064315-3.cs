    var myList = mydt.ConvertColumn<decimal, string>("colname", v => v.ToString("0.##"));
    
    static class DataTableExtension 
    {
        public static List<TResult> ConvertColumn<TColumn, TResult>(this DataTable datatable, string colName, Func<TColumn, TResult> converter)
        {
             return datatable.AsEnumerable().Select(r => converter(r.Field<TColumn>(colName))).ToList();          
        }
    }
