        private string ExcelConnection(string fileName)
        {
            return
                @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data Source=" + fileName + ";" +
                @"Extended Properties=" + Convert.ToChar(34).ToString() +
                @"Excel 8.0" + Convert.ToChar(34).ToString() + ";";
        }
        private DataTable readExcel(string fileName, string sql)
        {
            OleDbConnection conn = new OleDbConnection(ExcelConnection(fileName));
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            try
            {
                adp.FillSchema(dt, SchemaType.Source);
                adp.Fill(dt);
            }
            catch
            { 
                
            }
            return dt;
        }
