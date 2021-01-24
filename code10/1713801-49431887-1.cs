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
                    {"A", new Dictionary<string,string>(){{"U","s"}, {"Z","a"}}},
                    {"B", new Dictionary<string,string>(){{"W","e"},{"X","d"},{"Y","d"}}},
                    {"C", new Dictionary<string,string>(){{"V","f"}, {"W","a"},{"Z","w"}}},
                };
                string[] columns = OneTwoThree.Select(x => x.Key).OrderBy(x => x).ToArray();
                DataTable dt = new DataTable();
                dt.Columns.Add("TwoDetails", typeof(string));
                foreach(string column in columns)
                {
                    dt.Columns.Add(column, typeof(string));
                }
                string[] rows = OneTwoThree.Select(x => x.Value.Select(y => y.Key)).SelectMany(x => x).Distinct().OrderBy(x => x).ToArray();
                var flip = rows.Select(x => new { row = x, columns = OneTwoThree.Where(y => y.Value.ContainsKey(x)).Select(y => new { col = y.Key, value = y.Value[x] }).ToList() }).ToList();
                //create pivot table
                foreach (var row in flip)
                {
                    DataRow newRow = dt.Rows.Add();
                    newRow["TwoDetails"] = row.row;
                    foreach (var column in row.columns)
                    {
                        newRow[column.col] = column.value;
                    }
                }
            }
        }
    }
