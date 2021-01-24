    public static class ExcelUploader
    {
        static ArrayList data;
        static List<string> tableNames;
        static List<DbCommand> cmdList = new List<DbCommand>();
        static DbConnection conn;
        public static void Upload(string filePath)
        {
            data = new ArrayList();
            tableNames = new List<string>();
            //get Excel data to array list
            ArrayList upLoadData = ReadFile(filePath);
            using (var db = new DataContext())
            {
                conn = db.Database.Connection;
                //transform arraylist into a list of DbCommands
                ArrayListToCommandList(upLoadData);
                conn.Open();
                try
                {
                    foreach (var cmd in cmdList)
                    {
                        //Console.WriteLine(cmd.CommandText);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    var result = e.Message;
                    MessageBox.Show(result);
                }
            }
            
        }
        //opens Excel file and reads worksheets to arraylist
        private static ArrayList ReadFile(string fileName)
        {
            List<string> commands = new List<string>();
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            var wb = xlApp.Workbooks.Open(fileName, ReadOnly: true);
            xlApp.Visible = false;
            foreach (Worksheet ws in wb.Worksheets)
            {
                var r = ws.UsedRange;
                var array = r.Value;
                data.Add(array);
                tableNames.Add(ws.Name);
            }
            wb.Close(SaveChanges: false);
            xlApp.Quit();
            return data;
        }
        //transforms arraylist to a list of DbCommands
        private static void ArrayListToCommandList(ArrayList arrList)
        {
            List<DbCommand> result = new List<DbCommand>();
            for (int tableAmount = 0; tableAmount < data.Count; tableAmount++)
            {
                ArrayToSqlCommands(arrList[tableAmount] as Array, tableNames[tableAmount]);
            }
        }
        private static void ArrayToSqlCommands(Array arr, string tableName)
        {
            //Excel row which holds property names
            int propertyRow = 1;
            //First Excel row with values
            int firstDataRow = 2;
            string sql = "";
            DbCommand cmd = conn.CreateCommand();
            sql += "INSERT INTO " + tableName + "(";
            //add column names to command text
            for (int colIndex = 1; colIndex <= arr.GetUpperBound(1); colIndex++)
            {
                //get property name
                sql += arr.GetValue(propertyRow, colIndex);
                //add comma if not last column, otherwise close bracket
                if (colIndex == arr.GetUpperBound(1))
                {
                    sql += ") Values (";
                }
                else
                {
                    sql += ", ";
                }
            }
            //add value parameter names to command text
            for (int colIndex = 1; colIndex <= arr.GetUpperBound(1); colIndex++)
            {
                //get property name
                sql += "@" + arr.GetValue(propertyRow, colIndex);
                //add comma if not last column, otherwise close bracket
                if (colIndex == arr.GetUpperBound(1))
                {
                    sql += ");";
                }
                else
                {
                    sql += ", ";
                }
            }
            //add data elements as command parameter values
            for (int rowIndex = firstDataRow; rowIndex <= arr.GetUpperBound(0); rowIndex++)
            {
                //initialize command
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                for (int colIndex = 1; colIndex <= arr.GetUpperBound(1); colIndex++)
                {
                    //set parameter values
                    DbParameter param = null;
                    param = cmd.CreateParameter();
                    param.ParameterName = "@" + (string)arr.GetValue(propertyRow, colIndex);
                    cmd.Parameters.Add(param);
                    cmd.Parameters[param.ParameterName].Value = arr.GetValue(rowIndex, colIndex);
                }
                //add command to command list
                cmdList.Add(cmd);
                
            }
            
        }
    }
