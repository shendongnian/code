    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Department", typeof(string));
                dt.Columns.Add("Section", typeof(string));
                dt.Columns.Add("Employee ID", typeof(string));
                dt.Rows.Add(new object[] {"Production","Padding","102001"});
                dt.Rows.Add(new object[] {"Production","Padding","102002"});
                dt.Rows.Add(new object[] {"Production","Padding","102003"});
                dt.Rows.Add(new object[] {"Production","Sewing","103001"});
                dt.Rows.Add(new object[] {"Production","Sewing","103002"});
                dt.Rows.Add(new object[] {"HR & admin","admin","107001"});
                CreateHtml createHtml = new CreateHtml(dt);
     
            }
        }
        public class CreateHtml
        {
            public DataTable dt = null;
            public  StringWriter writer = new StringWriter();
            private int numberColumns = 0;
            public CreateHtml(DataTable dt)
            {
                this.dt = dt;
                numberColumns = dt.Columns.Count;
                writer.WriteLine("<html><body>");
                RecursiveWrite(0, dt.AsEnumerable().ToList());
                writer.WriteLine("</html></body>");
                string body = writer.ToString();
            }
            void RecursiveWrite(int level, List<DataRow> rows)
            {
                string leader = new string(' ', 5 * level);
                writer.WriteLine("{0}  <ul>", leader);
                var groups = rows.GroupBy(x => x[level]).ToList();
                foreach (var group in groups)
                {
                    if (level < numberColumns - 1)
                    {
                        writer.WriteLine("{0}   <li>{1}", leader, group.Key);
                        RecursiveWrite(level + 1, group.ToList());
                        writer.WriteLine("{0}   </li>", leader);
                    }
                    else
                    {
                        writer.WriteLine("{0}   <li>{1}</li>", leader, group.Key);
                    }
                }
                
                writer.WriteLine("{0}  </ul>", leader);
            }
        }
    }
