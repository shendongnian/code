    public class Program
    {
        public static void Main(string[] args)
        {
            dataSet = new DataSet();
            var dataTable = MakeTable();
            var columns = dataTable.Columns;
            Console.WriteLine("Defined Table");
            PrintDataTable(dataTable);
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                var id = dataTableRow["ID"];
                var burstTime = dataTable.Compute("Sum(BurstTime)", $"ID < {id}");
                dataTableRow["WaitingTime"] = burstTime;
            }
            Console.WriteLine();
            Console.WriteLine("Table After Operation");
            PrintDataTable(dataTable);
            Console.ReadLine();
        }
        private static void PrintDataTable(DataTable dataTable)
        {
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                Console.WriteLine($"{dataTableRow["Id"]}\t\t| {dataTableRow["WaitingTime"]}\t\t| {dataTableRow["BurstTime"]}");
            }
        }
        private static DataSet dataSet;
        private static DataTable MakeTable()
        {
            // Create a new DataTable.
            DataTable table = new DataTable("childTable");
            DataColumn column;
            DataRow row;
            // Create first column and add to the DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            column.AutoIncrement = true;
            column.Caption = "ID";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the column to the DataColumnCollection.
            table.Columns.Add(column);
            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ChildItem";
            column.AutoIncrement = false;
            column.Caption = "ChildItem";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            // Create third column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ParentID";
            column.AutoIncrement = false;
            column.Caption = "ParentID";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            // Create third column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "WaitingTime";
            column.AutoIncrement = false;
            column.Caption = "WaitingTime";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            // Create fourth column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "BurstTime";
            column.AutoIncrement = false;
            column.Caption = "BursTime";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            
            dataSet.Tables.Add(table);
            // Create three sets of DataRow objects, 
            // five rows each, and add to DataTable.
            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["ID"] = i;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 0;
                row["WaitingTime"] = 0;
                row["BurstTime"] = i;
                table.Rows.Add(row);
            }
            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["ID"] = i + 5;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 1;
                row["WaitingTime"] = 0;
                row["BurstTime"] = i + 5;
                table.Rows.Add(row);
            }
            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["ID"] = i + 10;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 2;
                row["WaitingTime"] = 0;
                row["BurstTime"] = i + 10;
                table.Rows.Add(row);
            }
            return table;
        }
    }
