    private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            List<string> FieldNames = new List<string>();
            foreach (var item in lstFieldNames.Items)
            {
                FieldNames.Add(lstFieldNames.Items.ToString());
            }
            var grpfieldNames = FieldNames.Distinct();
            DataTable NewCategory = new DataTable();
            NewCategory = CreateTable(grpfieldNames);
            dgPreviewAdd.DataSource = NewCategory;
            using (SqlConnection Connection = new SqlConnection(
               Helper.cnnVal("InventoryManager")))
            {
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.CommandText = "Create Table tbl" +
                        NewCategory.TableName.ToString() + "(ID int)";
                    Connection.Open();
                    command.ExecuteNonQuery();
                    Connection.Close();
                    foreach (DataColumn newColumn in NewCategory.Columns)
                    {
                        If(newColumn.ColumnName("ID")
                          {
                        }
                        Else
                          {
                            SqlParameter colparam = new SqlParameter();
                            colparam.ParameterName = "@ColumnName";
                            colparam.Value = newColumn.ColumnName.ToString();
                            SqlParameter tblParam = new SqlParameter();
                            tblParam.ParameterName = "@TableName";
                            tblParam.Value = "tbl" + NewCategory.TableName.ToString();
                            command.Parameters.Add(colparam);
                            command.Parameters.Add(tblParam);
                            command.CommandText = "dbo.AddCategoryColumns";
                            command.CommandType = CommandType.StoredProcedure;
                            Connection.Open();
                            command.ExecuteNonQuery();
                            Connection.Close();
                        }
                    }
                    LoadCategory catTableLoad = new LoadCategory();
                    DataTable catTable = new DataTable();
                    catTable = catTableLoad.getCategoryTable();
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@CategoryName";
                    param.Value = NewCategory.TableName.ToString();
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@IdNumber";
                    param2.Value = catTable.Rows.Count + 1;
                    command.Parameters.Add(param);
                    command.Parameters.Add(param2);
                    command.CommandText = "dbo.AddCategory";
                    command.CommandType = CommandType.StoredProcedure;
                    Connection.Open();
                    command.ExecuteNonQuery();
                    Connection.Close();
                }
            }
        }
