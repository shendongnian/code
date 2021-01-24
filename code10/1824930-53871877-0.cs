    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication93
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("DOB", typeof(string));
                dt.Rows.Add(new object[] {1,"2018-01-01"});
                dt.Rows.Add(new object[] {2,"2018-04-01"} );
                dt.Rows.Add(new object[] { 3, "2018-XX-01" });
                MyDate myDate = new MyDate();
                var results1 = dt.AsEnumerable()
                    .Where(x => myDate.Equals(x.Field<string>("DOB"),"2018-01-01"))
                    .ToList();
                var results2 = dt.AsEnumerable()
                     .Where(x => myDate.Equals(x.Field<string>("DOB"), "2018-XX-01"))
                     .ToList();
     
            }
        }
        public class MyDate : IEqualityComparer  
        {
            public new Boolean Equals(object x, object y)
            {
                string[] dateArrayX = ((string)x).Split(new char[] { '-' });
                string[] dateArrayY = ((string)y).Split(new char[] { '-' });
                Boolean yearCompare = (dateArrayX[0] == "XXXX") | (dateArrayY[0] == "XXXX") | (dateArrayX[0] == dateArrayY[0]);
                Boolean monthCompare = (dateArrayX[1] == "XX") | (dateArrayY[1] == "XX") | (dateArrayX[1] == dateArrayY[1]);
                Boolean dayCompare = (dateArrayX[2] == "XX") | (dateArrayY[2] == "XX") | (dateArrayX[2] == dateArrayY[2]);
                return yearCompare & monthCompare & dayCompare;
                
            }
            public int GetHashCode(object obj)
            {
                return obj.ToString().ToLower().GetHashCode();
            }
        }
     
     
    }
