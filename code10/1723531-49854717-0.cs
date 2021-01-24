    private void dtgrdvw_items_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                
                if (e.ColumnIndex == 1)
                {
                    int rowindex = dtgrdvw_items.CurrentCell.RowIndex;
                    int columnindex = dtgrdvw_items.CurrentCell.ColumnIndex;
                    SqlCommand cmd = new SqlCommand("Select * from item WHERE item_desc=@inv_item_desc", con);
                    cmd.Parameters.Add("@inv_item_desc", SqlDbType.VarChar).Value = dtgrdvw_items.Rows[rowindex].Cells[columnindex].Value.ToString();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dtgrdvw_items.Rows[rowindex].Cells[0].Value = dr[0].ToString();
                        dtgrdvw_items.Rows[rowindex].Cells[1].Value = dr[1].ToString();
                        dtgrdvw_items.Rows[rowindex].Cells[3].Value = dr[2].ToString();
                    }
                    dr.Close();
                }
             if (e.ColumnIndex == 2)
                {
    
                    int cell1 = Convert.ToInt32(dtgrdvw_items.CurrentRow.Cells[2].Value);
    
                    Decimal cell2 = Convert.ToDecimal(dtgrdvw_items.CurrentRow.Cells[3].Value);
    
                    if (cell1.ToString() != "" && cell2.ToString() != "")
                    {
    
                        dtgrdvw_items.CurrentRow.Cells[4].Value = cell1 * cell2;
    
                    }
                }
            }
