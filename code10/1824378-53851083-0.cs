    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication93
    {
        class Program
        {
            static void Main(string[] args)
            {
                Order order = new Order();
                DataTable dt = order.MakeTable();
                //now create piviot table
                string[] dates = dt.AsEnumerable().Select(x => x.Field<string>("Date")).Distinct().ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("ProductID", typeof(string));
                foreach (string date in dates)
                {
                    pivot.Columns.Add(date, typeof(int));
                }
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<string>("ProductID")).ToList();
                foreach(var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    newRow["ProductID"] = group.Key;
                    foreach (var col in group)
                    {
                        newRow[col.Field<string>("Date")] = col.Field<int>("Amount");
                    }
                }
     
            }
        }
        internal class Order
        {
            public Order()
            {
            }
            public string ProductID { get; set; }
            public int Amount { get; set; }
            public string Date { get; set; }
            public DataTable MakeTable()
            {
                DataTable dt = new DataTable();
                List<Order> orderList = new List<Order>() {
                    new Order(){ ProductID="12345", Amount=300, Date = "2018-12-19"},
                    new Order(){ ProductID="12345", Amount=0, Date = "2018-12-20"},
                    new Order(){ ProductID="12345", Amount=200, Date = "2018-12-21"},
                    new Order(){ ProductID="12345", Amount=250, Date = "2018-12-22"},
                    new Order(){ ProductID="12345", Amount=30, Date = "2018-12-23"},
                    new Order(){ ProductID="67898", Amount=20, Date = "2018-12-20"},
                    new Order(){ ProductID="67898", Amount=30, Date = "2018-12-21"},
                    new Order(){ ProductID="67898", Amount=40, Date = "2018-12-22"},
                    new Order(){ ProductID="67898", Amount=50, Date = "2018-12-23"},
                    new Order(){ ProductID="67898", Amount=130, Date = "2018-12-24"}
                };
                foreach (var prop in this.GetType().GetProperties())
                {
                    string typeName = prop.PropertyType.FullName;
                    Type systemType = System.Type.GetType(typeName);
                    dt.Columns.Add(prop.Name, systemType);
                }
                foreach (Order row in orderList)
                {
                    object[] data = row.GetType().GetProperties().Select(x => x.GetValue(row, null)).ToArray();
                    dt.Rows.Add(data);
                }
                return dt;
            }
        }
    }
