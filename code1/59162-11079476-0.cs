    static void Main(string[] args)
    {
        DoUnion();
    }
    
    private static void DoUnion()
    {
        DataTable table1 = GetProducts();
        DataTable table2 = NewProducts();
        var tbUnion = table1.AsEnumerable()
            .Union(table2.AsEnumerable());
        DataTable unionTable = table1.Clone();
        foreach (DataRow fruit in tbUnion)
        {
            var fruitValue = fruit.Field<string>(0);
            Console.WriteLine("{0}->{1}", fruit.Table, fruitValue);
            DataRow row = unionTable.NewRow();
            row.SetField<string>(0, fruitValue);
            unionTable.Rows.Add(row);
        }
    }
    
    private static DataTable NewProducts()
    {
        DataTable table = new DataTable("CitricusTable");
        DataColumn col = new DataColumn("product", typeof(string));
        table.Columns.Add(col);
        string[] citricusFruits = { "Orange", "Grapefruit", "Lemon", "Lime", "Tangerine" };
        foreach (string fruit in citricusFruits)
        {
            DataRow row = table.NewRow();
            row.SetField<string>(col, fruit);
            table.Rows.Add(row);
        }
        return table;
    }
    
    private static DataTable GetProducts()
    {
        DataTable table = new DataTable("MultipleFruitsTable");
        DataColumn col = new DataColumn("product", typeof(string));
        table.Columns.Add(col);
        string[] multipleFruits = { "Breadfruit", "Custardfruit", "Jackfruit", "Osage-orange", "Pineapple" };
        foreach (string fruit in multipleFruits)
        {
            DataRow row = table.NewRow();
            row.SetField<string>(col, fruit);
            table.Rows.Add(row);
        }
        return table;
    }
