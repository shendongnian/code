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
                Outlining outling = new Outlining();
                outling.Add(2,2);
                outling.Add(0, 2);
                outling.Add(5, 2);
            }
        }
        public class Outlining
        {
            public DataTable dt = null;
            public Outlining()
            {
                dt = new DataTable();
                dt.Columns.Add("L1", typeof(int));
                dt.Columns.Add("L2", typeof(int));
                dt.Columns.Add("L3", typeof(int));
                dt.Columns.Add("L4", typeof(int));
                dt.Columns.Add("L5", typeof(int));
                dt.Rows.Add(new object[] { 1, 0, 0, 0, 0 });
                dt.Rows.Add(new object[] { 1, 1, 0, 0, 0 });
                dt.Rows.Add(new object[] { 1, 1, 1, 0, 0 });
                dt.Rows.Add(new object[] { 1, 2, 0, 0, 0 });
            }
            public void Add(int at, int level)
            {
                DataRow newRow = dt.Rows.Add();
                if (at < dt.Rows.Count - 1)
                {
                    //move row if not last row
                    dt.Rows.Remove(newRow);
                    dt.Rows.InsertAt(newRow, at);
                }
                newRow.BeginEdit();
                newRow.ItemArray = dt.Rows[at + 1].ItemArray.Select(x => (object)x).ToArray();
                newRow.EndEdit();
                Renumber(at, level);
            }
            public void Renumber(int rowInsertIndex, int level)
            {
                for (int row = rowInsertIndex; row < dt.Rows.Count - 1; row++)
                {
                    Boolean match = true;
                    //check if columns to left still match, if no we are done
                    for (int i = 0; i < level - 1; i++)
                    {
                        if (dt.Rows[i][level] != dt.Rows[i + 1][level])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (!match) break;
                    dt.Rows[row + 1][level] = ((int)(dt.Rows[row + 1][level])) + 1;
                }
            }
        }
    }
