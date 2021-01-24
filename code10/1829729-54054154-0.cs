    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {           
            try
            {
                int column=excelGridview.CurrentCell.ColumnIndex;
                int row = excelGridview.CurrentCell.RowIndex;
                int country = Convert.ToInt32(((ComboBox)sender).SelectedValue);
     
                if (column == 7)
                {
                    MyConnect myCnn = new MyConnect();  
                    String connString = myCnn.getConnect().ToString();
     
     
                    SqlConnection conn;
                    SqlCommand command;
                    conn = new SqlConnection(connString);
                    command = new SqlCommand();
     
                    
                    if (country > 0)
                    {
                        try
                        {
                            conn.Open();
     
                            string query = "select regionID FROM  countryinfo country  WHERE country.ID=" + country + "";
     
                            command = new SqlCommand(query, conn);
     
                            SqlDataReader reader = command.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(reader);
     
                            var currentcell = excelGridview.CurrentCellAddress;
                            DataGridViewComboBoxCell cel = (DataGridViewComboBoxCell)excelGridview.Rows[currentcell.Y].Cells[8];
     
                            cel.Value = Convert.ToInt64(dt.Rows[0]["regionID"]);
                             
                            conn.Close();
     
                        }
                        catch (Exception ex1)
                        {
                        }
                        finally
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception) { }           
    }
