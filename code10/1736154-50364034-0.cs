    class MyClass
    {
        public int MyProperty { get; set; }
    }
    public static void Main(string[] args)
    {
        DataTable table = new DataTable();
        table.Columns.Add("MyProperty", typeof(int));
        table.Rows.Add(1);
        table.Rows.Add(2);
        table.Rows.Add(3);
        List<MyClass> result = (from t in table.AsEnumerable()
                                select new MyClass
                                {
                                    MyProperty = t.Field<int>("MyProperty")
                                }).ToList();
    }
