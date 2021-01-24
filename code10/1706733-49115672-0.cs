    Public bool InsertIntoDB(string tableName, DataTable _dataTable)
        {
            bool Result = false;
            DataTable ColumnsSQL = GetColumns(tableName);
            string CommandInsert = "Insert Into " + tableName + " (";
            string CommandValue = "";
            string commandSQL = "";
            DateTime Helpconstruct = new DateTime();
            String Word = "";
            String ValueToAdd = ""; 
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            FuncAuxC2C HELPPLEASE = new FuncAuxC2C();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(null, conn);
    
            for (int k = 0; k < _dataTable.Rows.Count; k++)
            {
    
                for (int i = 0; i < ColumnsSQL.Rows.Count - 1; i++)
                {
                    CommandInsert += ColumnsSQL.Rows[i][0].ToString();
    
                    if (_dataTable.Rows[k][i].ToString() != "")
                    {
                        ValueToAdd = _dataTable.Rows[k][i].ToString();
                        if (char.IsNumber(ValueToAdd[0]))
                        {
                            bool haveDigits = false;
    
                            foreach (char c in _dataTable.Rows[k][i].ToString())
                            {
                                if (c < '0' || c > '9')
                                {
                                    haveDigits = true;
                                    continue;
                                }
    
                            }
   
                            if (haveDigits == true && _dataTable.Rows[k][i].ToString().Contains("e+") && _dataTable.Rows[k][i].ToString().Contains(","))
                            {
                                
                                _dataTable.Rows[k][i] = Decimal.Parse(_dataTable.Rows[k][i].ToString(), System.Globalization.NumberStyles.Float).ToString();
    
                            }
                        }
                    }
    
                    if (_dataTable.Columns[i].ColumnName.ToString() == "Data" && _dataTable.Rows[k][i].ToString() != "")
                    {
    					//This is just to format date
                        ValueToAdd = HELPPLEASE.alterDataformat(_dataTable.Rows[k][i].ToString(), "yyyyMMdd", "-");
    
                    }
                    else if (_dataTable.Columns[i].ColumnName.ToString() == "tipificacao_datetime" && _dataTable.Rows[k][i].ToString() != "" )
                    {
    					//This is just to format date 
                        ValueToAdd = HELPPLEASE.alterDataformat(_dataTable.Rows[k][i].ToString(), "yyyyMMddHHMMSS", "-");
                    }
                    else
                    {
                        if (_dataTable.Rows[k][i].ToString().Length < 250)
                        {
                            ValueToAdd = _dataTable.Rows[k][i].ToString();
                        }
                        else
                        {
                            ValueToAdd = _dataTable.Rows[k][i].ToString().Substring(0, 250);
                        }
                    }
    
    
                    cmd.Parameters.AddWithValue("@" + ColumnsSQL.Rows[i][0].ToString(), SqlDbType.VarChar).Value = ValueToAdd;
                    ValueToAdd = "";
    
    
                    CommandValue += "@" + ColumnsSQL.Rows[i][0].ToString();
    
                    if (ColumnsSQL.Rows.Count - 2 != i)
                    {
                        CommandInsert += ", ";
                        CommandValue += ", ";
                    }
    
                }
    
    
    
                commandSQL = CommandInsert + ") VALUES (" + CommandValue + ")";
                try
                {
    
                    conn.Open();
                    cmd.CommandText = commandSQL;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cmd.Parameters.Clear();
    
                    commandSQL = "";
                    CommandValue = "";
                    CommandInsert = "";
                    CommandInsert = "Insert Into " + tableName + " (";
                    Result = true;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    Result = false;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    commandSQL = "";
                    CommandValue = "";
                    CommandInsert = "";
                    CommandInsert = "Insert Into " + tableName + " (";
                    conn.Close();
                }
            }
    
    
            return Result;
        }
    
    }
