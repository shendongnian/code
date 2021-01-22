    public class Table{
    public string Column1 { get; set; }
    public int Column2 { get; set; }}
     public static IEnumerable<T> GetDataSource<T>()
        {
            MyEntity myEntity = new MyEntity();
            if (typeof(T) == typeof(Table))
            {
                IQueryable<Table> query = from x in myEntity.Table1
                       select new Table
                       {
                           Column1 = x.TheColumn1,
                           Column2 = x.TheColumn2
                       };
               return query.ToList().Cast<T>();
            }
            if (typeof(T) == typeof(Table2))
            {
                IQueryable<Table2> query = from x in myEntity.Table2
                       select new Table2
                       {
                           TestColumn1 = x.TheColumn123,
                           TestColumn2 = x.TheColumn321
                       };
                return query.ToList().Cast<T>();
            }
            return Enumerable.Empty<T>();
        }
