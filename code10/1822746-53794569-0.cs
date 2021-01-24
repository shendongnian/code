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
                Index index = new Index(FILENAME);
                index.loadgridbyxml();
                DataTable results = index.ds.Tables["ZZZ"].AsEnumerable().Where(x => int.Parse(x.Field<string>("Qty")) > 10).CopyToDataTable();
            }
        }
        public class Index
        {
            public DataSet ds = null;
            string filename = "";
            public Index(string filename)
            {
                this.filename = filename;
            }
            public void loadgridbyxml()
            {
                ds = new DataSet();
                ds.ReadXml(filename);
            }
        }
    }
