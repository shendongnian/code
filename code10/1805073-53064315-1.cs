    var myList = mydt.ConvertColumn<decimal, string>("colname", v => v.ToString("0.##"));
    
    static class DataTableExtension 
    {
        public static List<TResult> ConvertColumn<T, TResult>(this DataTable datatable, string colName, Func<T, TResult> converter)
        {
             return datatable.AsEnumerable().Select(r => converter(r.Field<T>(colName))).ToList();          
        }
    }
