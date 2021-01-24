       public static void CopyDataTableToExcel(DataTable dtExcel, String excelOutputTemplate, string outExcelPath)
        {
            File.Copy(excelOutputTemplate, outExcelPath, true);
            string qryFieldName = "";
            string qryFieldForCreate = "";
            string qryFieldValue = "";
            string qryFieldValueTemp = "";
            string qryInsert = "";
            for (int i = 0; i < dtExcel.Columns.Count; i++)
            {
                qryFieldName = qryFieldName + (qryFieldName.Trim() != "" ? ", " : "") + "[" + dtExcel.Columns[i].ColumnName + "]";
                qryFieldForCreate = qryFieldForCreate + (qryFieldForCreate.Trim() != "" ? ", " : "") +
                     "[" + dtExcel.Columns[i].ColumnName + "] varchar(255)";
            }
            // Establish a connection to the data source.
            System.Data.OleDb.OleDbConnection objConn = new System.Data.OleDb.OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + outExcelPath + "';Extended Properties=\"Excel 12.0;HDR=YES;\"");
            objConn.Open();
            // Add two records to the table named 'MyTable'.
            System.Data.OleDb.OleDbCommand objCmd = new System.Data.OleDb.OleDbCommand();
            objCmd.Connection = objConn;
            qryInsert = "Create table InventorySheet (" + qryFieldForCreate + ")";
            objCmd.CommandText = qryInsert;
            objCmd.ExecuteNonQuery();
            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                qryFieldValue = "";
                for (int j = 0; j < dtExcel.Columns.Count; j++)
                {
                    qryFieldValueTemp = dtExcel.Rows[i][j].ToString();
                    if (qryFieldValueTemp.Length > 255)
                    {
                        qryFieldValueTemp = qryFieldValueTemp.Substring(qryFieldValueTemp.Length - 255);
                    }
                    qryFieldValue = qryFieldValue + (qryFieldValue.Trim() != "" ? ", '" : "'") + qryFieldValueTemp.Replace("'", "''") + "'";
                }
                //qryInsert = "Insert into [Sheet1$] Values (" + qryFieldValue + ")";
                qryInsert = "Insert into InventorySheet (" + qryFieldName + ") Values (" + qryFieldValue + ")";
                objCmd.CommandText = qryInsert;
                objCmd.ExecuteNonQuery();
            }
            // Close the connection.
            objConn.Close();
            MessageBox.Show("Exported successfully.");
        }
