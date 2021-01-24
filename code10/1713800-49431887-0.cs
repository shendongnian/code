    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication31
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, Dictionary<string, string>> OneTwoThree = new Dictionary<string, Dictionary<string, string>>() {
                    {"U", new Dictionary<string,string>(){{"A","s"}}},
                    {"V", new Dictionary<string,string>(){{"C","f"}}},
                    {"W", new Dictionary<string,string>(){{"B","e"}, {"C","a"}}},
                    {"X", new Dictionary<string,string>(){{"B","d"}}},
                    {"Y", new Dictionary<string,string>(){{"B","d"}}},
                    {"Z", new Dictionary<string,string>(){{"A","a"}, {"C","w"}}}
                };
                string[] columns = OneTwoThree.Select(x => x.Value.Select(y => y.Key)).SelectMany(x => x).Distinct().OrderBy(x => x).ToArray();
                DataTable dt = new DataTable();
                dt.Columns.Add("TwoDetails", typeof(string));
                foreach(string column in columns)
                {
                    dt.Columns.Add(column, typeof(string));
                }
                //create pivot table
                foreach (var dict in OneTwoThree)
                {
                    DataRow newRow = dt.Rows.Add();
                    newRow["TwoDetails"] = dict.Key;
                    foreach (var column in dict.Value)
                    {
                        newRow[column.Key] = column.Value;
                    }
                }
            }
        }
    }
