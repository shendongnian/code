    class Program
        {
            static void Main(string[] args)
            {
                var dt = new DataTable { Columns = { "A3", "A2", "B1", "B3", "B2", "A1" } };
                dt.BeginLoadData();
                dt.Rows.Add("A3val", "A2val", "B1val", "B3val", "B2val", "A1val");
                dt.EndLoadData();
    
                string[] names=new string[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count;i++ )
                {
                    names[i] = dt.Columns[i].ColumnName;
                }
                Array.Sort(names);
    
                foreach (var name in names)
                {
                    Console.Out.WriteLine("{0}={1}", name, dt.Rows[0][name]);
                }
                Console.ReadLine();
            }
