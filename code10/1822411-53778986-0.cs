    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Data;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
                Console.WriteLine("Hello, world!");
                DataTable table = new DataTable();
                table.Columns.Add("Dosage", typeof(int));
                table.Columns.Add("Drug", typeof(string));
                table.Columns.Add("Patient", typeof(string));
                //table.Columns.Add("Date", typeof(DateTime));
    
                // Here we add five DataRows.
                table.Rows.Add(25, "Indocin", "David");
                table.Rows.Add(50, "Enebrel", "Sam");
                table.Rows.Add(10, "Hydralazine", "Christoff");
                table.Rows.Add(21, "Combivent", "Janet");
                table.Rows.Add(100, "Dilantin", "Melanie");
                if(table.Rows.Count > 0)
                {
                    for(int i = 0; i < table.Columns.Count; i++){
                        string columnName = Convert.ToString(table.Columns[i]);
                        table.Columns[columnName].ColumnName = Convert.ToString(table.Rows[0][i]);
                    }
                }
                
                for(int i = 0; i < table.Columns.Count; i++){
                    Console.WriteLine(table.Columns[i]);
                }
            }
        }
    }
