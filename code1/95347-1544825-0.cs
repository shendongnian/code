    public class Table
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }
    public static IEnumerable<Table> GetDataSource(string QueryName)
    {
        MyEntity myEntity = new MyEntity();
        switch (QueryName)
        {
            case "FirstQuery":
                return from x in myEntity.TableName
                       select new Table
                       {
                           Column1 = x.FirstColumn,
                           Column2 = x.SecondColumn
                       };
        }
        return Enumerable.Empty<Table>();
    }
