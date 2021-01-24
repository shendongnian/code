    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable Dao = new DataTable();
                var groups = Dao.AsEnumerable().GroupBy(x => x.Field<DateTime>("date").Date).ToList();
                DataTable sumTable = Dao.Clone();
                int numberOfColumns = sumTable.Columns.Count;
                foreach (var group in groups)
                {
                    DataRow newRow = sumTable.Rows.Add();
                    newRow["date"] = group.Key;
                    for (int col = 1; col < numberOfColumns; col++)
                    {
                        newRow[col] = group.Sum(x => (int)x[col]);
                    }
                }
            }
        }
    }
 
