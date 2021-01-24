    //for validating column names
        public List<DataExchangeDefinition> ValidateColumnNames(string filename, List<DataExchangeDefinition> dataExchangeDefinitionList)
        {
            DataExchangeDefinition dt = new DataExchangeDefinition();
         
            //List<DataExchangeDefinition> dataexchangedefinitionList = new List<DataExchangeDefinition>();
            string extension = Path.GetExtension(filename);
            string connstring = string.Empty;
            try
            {
                switch (extension)
                {
                    case ".xls":
                        connstring = string.Format(ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString, filename);
                        break;
                    case ".xlsx":
                        connstring = string.Format(ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString, filename);
                        break;
                }
                using (OleDbConnection connExcel = new OleDbConnection(connstring))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = connExcel;
                        connExcel.Open();
                        var dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null); //To get the sheet name
                        connExcel.Close();
                        string firstSheet = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        cmd.CommandText = "SELECT top 1 * FROM [" + firstSheet + "]";
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            DataTable HeaderColumns = new DataTable();
                            da.SelectCommand = cmd;
                            da.Fill(HeaderColumns);
                            //List<DataColumn> excelColumn = new List<DataColumn>();
                            //var excelColumn = new List<DataColumn>();
                            //foreach (DataColumn column in HeaderColumns.Columns)
                            //{
                            //    excelColumn.Add(column);                               
                            //}
                                foreach (DataExchangeDefinition data in dataExchangeDefinitionList)
                                //for(int i=0;i<dataExchangeDefinitionList.Count;i++)
                            {
                                dt.IsColumnValid = false;
                                //var result = from excelColumn in HeaderColumns;
                                foreach (DataColumn column in HeaderColumns.Columns)
                                {
                                    if (data.FieldCaption == column.Caption)
                                    {
                                        data.IsColumnValid = true;
                                        break;
                                    }
                                }
                            }
                            return dataExchangeDefinitionList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return isColumnValid;
        }
    }
}
