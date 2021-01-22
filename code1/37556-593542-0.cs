    using System;
    using System.Data;
    static class Program
    {
        static void Main()
        {
            DataTable table = CreateEmptyTable();
            table.Rows.Add(1, "abc");
            table.Rows.Add(2, "def");
            WriteTable(table);
            table.WriteXml("t.xml", XmlWriteMode.IgnoreSchema);
    
            DataTable clone = CreateEmptyTable();        
            clone.ReadXml("t.xml");
            WriteTable(clone);
        }
        static DataTable CreateEmptyTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Foo", typeof(int));
            table.Columns.Add("Bar", typeof(string));
            table.TableName = "MyTable"; // THIS LINE MAKES IT ALL WORK
            return table;
        }
        static void WriteTable(DataTable table) {
            foreach (DataColumn col in table.Columns)
            {
                Console.Write(col.ColumnName);
                Console.Write('\t');
            }
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.Write(row[col]);
                    Console.Write('\t');
                }
                Console.WriteLine();
            }
        }
    }
