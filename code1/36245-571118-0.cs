    using System;
    using System.Data; 
    using System.Data.OleDb; 
    using SpreadsheetGear;
    using SpreadsheetGear.Advanced.Cells;
    using System.Diagnostics;
    namespace SpreadsheetGearAndOleDBBenchmark
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Warm up (get the code JITed).
                BM(10, 10);
                // Do it for real.
                BM(50000, 10);
            }
            static void BM(int rows, int cols)
            {
                // Compare the performance of OleDB to SpreadsheetGear for reading
                // workbooks. We sum numbers just to have something to do.
                //
                // Run on Windows Vista 32 bit, Visual Studio 2008, Release Build,
                // Run Without Debugger:
                //  Create time: 0.25 seconds
                //  OleDb Time: 0.63 seconds
                //  SpreadsheetGear Time: 0.31 seconds
                //
                // SpreadsheetGear is more than twice as fast at reading. Furthermore,
                // SpreadsheetGear can create the file and read it faster than OleDB
                // can just read it.
                string filename = @"C:\tmp\SpreadsheetGearOleDbBenchmark.xls";
                Console.WriteLine("\nCreating {0} rows x {1} columns", rows, cols);
                Stopwatch timer = Stopwatch.StartNew();
                double createSum = CreateWorkbook(filename, rows, cols);
                double createTime = timer.Elapsed.TotalSeconds;
                Console.WriteLine("Create sum of {0} took {1} seconds.", createSum, createTime);
                timer = Stopwatch.StartNew();
                double oleDbSum = ReadWithOleDB(filename);
                double oleDbTime = timer.Elapsed.TotalSeconds;
                Console.WriteLine("OleDb sum of {0} took {1} seconds.", oleDbSum, oleDbTime);
                timer = Stopwatch.StartNew();
                double spreadsheetGearSum = ReadWithSpreadsheetGear(filename);
                double spreadsheetGearTime = timer.Elapsed.TotalSeconds;
                Console.WriteLine("SpreadsheetGear sum of {0} took {1} seconds.", spreadsheetGearSum, spreadsheetGearTime);
            }
            static double CreateWorkbook(string filename, int rows, int cols)
            {
                IWorkbook workbook = Factory.GetWorkbook();
                IWorksheet worksheet = workbook.Worksheets[0];
                IValues values = (IValues)worksheet;
                double sum = 0.0;
                Random rand = new Random();
                // Put labels in the first row.
                foreach (IRange cell in worksheet.Cells[0, 0, 0, cols - 1])
                    cell.Value = "Cell-" + cell.Address;
                // Using IRange and foreach be less code, 
                // but we'll do it the fast way.
                for (int row = 1; row <= rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        double number = rand.NextDouble();
                        sum += number;
                        values.SetNumber(row, col, number);
                    }
                }
                workbook.SaveAs(filename, FileFormat.Excel8);
                return sum;
            }
            static double ReadWithSpreadsheetGear(string filename)
            {
                IWorkbook workbook = Factory.GetWorkbook(filename);
                IWorksheet worksheet = workbook.Worksheets[0];
                IValues values = (IValues)worksheet;
                IRange usedRahge = worksheet.UsedRange;
                int rowCount = usedRahge.RowCount;
                int colCount = usedRahge.ColumnCount;
                double sum = 0.0;
                // We could use foreach (IRange cell in usedRange) for cleaner 
                // code, but this is faster.
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 0; col < colCount; col++)
                    {
                        IValue value = values[row, col];
                        if (value != null && value.Type == SpreadsheetGear.Advanced.Cells.ValueType.Number)
                            sum += value.Number;
                    }
                }
                return sum;
            }
            static double ReadWithOleDB(string filename)
            {
                String connectionString =  
                    "Provider=Microsoft.Jet.OLEDB.4.0;" + 
                    "Data Source=" + filename + ";" + 
                    "Extended Properties=Excel 8.0;"; 
                OleDbConnection connection = new OleDbConnection(connectionString); 
                connection.Open(); 
                OleDbCommand selectCommand =new OleDbCommand("SELECT * FROM [Sheet1$]", connection); 
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(); 
                dataAdapter.SelectCommand = selectCommand; 
                DataSet dataSet = new DataSet(); 
                dataAdapter.Fill(dataSet); 
                connection.Close(); 
                double sum = 0.0;
                // We'll make some assumptions for brevity of the code.
                DataTable dataTable = dataSet.Tables[0];
                int cols = dataTable.Columns.Count;
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < cols; i++)
                    {
                        object val = row[i];
                        if (val is double)
                            sum += (double)val;
                    }
                }
                return sum;
            }
        }
    }
