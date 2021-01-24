              Excel_OLE_Cmd.CommandText = "Create table [" + SheetName + "]  (" + 
                TableColumns + ")";//SheetName should be in []
                                                                                                                       
                Excel_OLE_Cmd.ExecuteNonQuery();
                //Write Data to Excel Sheet from DataTable dynamically
                foreach (System.Data.DataTable table in Results.Tables)
                {
                    String sqlCommandInsert = "";
                    String sqlCommandValue = "";
                    foreach (DataColumn dataColumn in table.Columns)
                    {
                        sqlCommandValue += dataColumn + "],[";
                    }
                    sqlCommandValue = "[" + sqlCommandValue.TrimEnd(',');
                    sqlCommandValue = sqlCommandValue.Remove(sqlCommandValue.Length - 2);
                    sqlCommandInsert = "INSERT into [" + SheetName + "] (" + sqlCommandValue + ") VALUES (";
