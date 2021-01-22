    foreach (DataRow row in dtData.Rows)
            {
                if (row["Column_name"].ToString() == txtBox.Text)
                {
                    // Getting the sequence number from the textbox.
                    string strName1 = txtRowDeletion.Text;
    
                    // Creating the SqlCommand object to access the stored procedure
                    // used to get the data for the grid.
                    string strDeleteData = "Sp_name";
                    SqlCommand cmdDeleteData = new SqlCommand(strDeleteData, conn);
                    cmdDeleteData.CommandType = System.Data.CommandType.StoredProcedure;
    
                    // Running the query.
                    conn.Open();
                    cmdDeleteData.ExecuteNonQuery();
                    conn.Close();
    
                    GetData();
    
                    dtData = (DataTable)Session["GetData"];
                    BindGrid(dtData);
    
                    lblMsgForDeletion.Text = "The row successfully deleted !!" + txtRowDeletion.Text;
                    txtRowDeletion.Text = "";
                    break;
                }
                else
                {
                    lblMsgForDeletion.Text = "The row is not present ";
                }
            }
