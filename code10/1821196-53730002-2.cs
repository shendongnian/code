    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication92
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                //source datatable
                DataTable dt = new DataTable();
                var groups = dt.AsEnumerable().GroupBy(x => new { a = x.Field<string>("ColumnA"), b = x.Field<string>("ColumnB"), c = x.Field<string>("ColumnC") }).ToList();
                DataSet ds = new DataSet();
                foreach(var group in groups)
                {
                    DataTable newDt = group.CopyToDataTable();
                    dt.TableName = string.Join("_", new object[] { group.Key.a, group.Key.b, group.Key.c });
                    ds.Tables.Add(newDt);
                }
                ds.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
            }
        }
    }
