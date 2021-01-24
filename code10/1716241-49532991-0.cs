    public static T RowToObjectClass<T>(DataRow r) where T : new()
    {
        T obj = new T();
        foreach (PropertyInfo pi in typeof(T).GetProperties().Where(p => p.CanWrite))
        {
            pi.SetValue(obj, Convert.ChangeType(r[pi.Name], pi.PropertyType));
        }
        return obj;
    }
    static void Main(string[] args)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("id", typeof(string)));
        dt.Columns.Add(new DataColumn("date", typeof(string)));
        dt.Rows.Add(new object[] { 1.ToString(), new DateTime(2018, 1, 1).ToString() });
        dt.Rows.Add(new object[] { 2.ToString(), new DateTime(2018, 2, 2).ToString() });
        foreach (DataRow r in dt.Rows)
        {
            Console.WriteLine("Row:   " + r[0].ToString() + " (" + r[0].GetType() + ")" + ", " + r[1].ToString() + " (" + r[1].GetType() + ")");
            MyClass c = RowToObjectClass<MyClass>(r);
            Console.WriteLine("Class: " + c.Id.ToString() + " (" + c.Id.GetType() + ")" + ", " + c.Date.ToString() + " (" + c.Date.GetType() + ")");
        }
    }
    public class MyClass
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
