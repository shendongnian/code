    using System.Data;
    
    class Program
    {
        static void Main(string[] args)
        {
            var dt = new DataTable();
    
            var res = from x in dt.AsEnumerable()
                      where x.Field<string>("something") == "value"
                      select x.Field<decimal>("decimalfield");
    
            var res2 = dt.AsEnumerable()
                .Where(y => y.Field<string>("something") == "value")
                .Select(y => y.Field<decimal>("decimalfield"));
        }
    }
