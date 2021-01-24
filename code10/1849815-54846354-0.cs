    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable("Array");
                dt.Columns.Add("Col_A", typeof(int));
                dt.Columns.Add("Col_B", typeof(int));
                dt.Columns.Add("Col_C", typeof(int));
                dt.Columns.Add("Col_D", typeof(int));
                dt.Columns.Add("Col_E", typeof(int));
                dt.Rows.Add(new object[] {0, 1, 3, 4, 2});
                dt.Rows.Add(new object[] {1, 0, 4, 2, 6});
                dt.Rows.Add(new object[] {3, 4, 0, 7, 1});
                dt.Rows.Add(new object[] {4, 2, 7, 0, 7});
                dt.Rows.Add(new object[] {2, 6, 1, 7, 0});
                dt.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
            }
        }
    }
