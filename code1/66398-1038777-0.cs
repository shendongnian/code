    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static DataTable getDataTable()
            {
                DataTable table = new DataTable();
                table.Columns.Add("userID", typeof(int));
                table.Columns.Add("userName", typeof(string));
                table.Columns.Add("isAwesome", typeof(bool));
                return table;
            }
    
            static DataRow getRow(DataTable table, int userID, string userName, bool isAwesome)
            {
                DataRow row = table.NewRow();
                row["userID"] = userID;
                row["userName"] = userName;
                row["isAwesome"] = isAwesome;
                return row;
            }
    
            static void printTable(DataTable table)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (object val in row.ItemArray)
                    {
                        Console.Write("{0}, ", val);
                    }
                    Console.WriteLine();
                }
            }
    
    
            static void Main(string[] args)
            {
                DataTable table = getDataTable();
                table.Rows.Add(getRow(table, 1, "Juliet", true));
                table.Rows.Add(getRow(table, 2, "Sean Hannity", false));
                table.Rows.Add(getRow(table, 3, "Charles Darwin", true));
    
                Console.WriteLine("Before:");
                printTable(table);
    
                // adding a row at index 1, between me and Sean Hannity
                Console.WriteLine("------------\nAfter:");
                DataRow barackRow = getRow(table, 4, "Barack Obama", true);
                table.Rows.InsertAt(barackRow, 1);
                printTable(table);
    
                Console.Write("Press any key. . .");
                Console.ReadKey(true);
            }        
        }
    }
