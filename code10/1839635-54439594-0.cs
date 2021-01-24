    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication98
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("1stChoice", typeof(string));
                dt.Columns.Add("2Choice", typeof(string));
                dt.Columns.Add("3rdChoice", typeof(string));
                dt.Rows.Add(new object[] { 1, "AA", "BB", "CC" });
                dt.Rows.Add(new object[] { 2, "CC", "BB", "AA" });
                dt.Rows.Add(new object[] { 3, "AA", "CC", "BB" });
                dt.Rows.Add(new object[] { 4, "BB", "AA", "CC" });
                dt.Rows.Add(new object[] { 5, "AA", "CC", "BB" });
                string[] fields = dt.AsEnumerable().SelectMany(x => x.ItemArray.Skip(1).Select(y => (string)y)).Distinct().OrderBy(x => x).ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("Field", typeof(string));
                pivot.Columns.Add("1stChoice", typeof(string));
                pivot.Columns.Add("2Choice", typeof(string));
                pivot.Columns.Add("3rdChoice", typeof(string));
                foreach (string field in fields)
                {
                    int firstChoice = dt.AsEnumerable().Where(x => x.Field<string>("1stChoice") == field).Count();
                    int secondChoice = dt.AsEnumerable().Where(x => x.Field<string>("2Choice") == field).Count();
                    int thirdChoice = dt.AsEnumerable().Where(x => x.Field<string>("3rdChoice") == field).Count();
                    pivot.Rows.Add(new object[] { field, firstChoice, secondChoice, thirdChoice }); 
                }
            }
        }
     
    }
