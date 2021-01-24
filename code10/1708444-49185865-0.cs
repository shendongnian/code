    var command = new System.Data.SqlClient.SqlCommand();
    command.CommandType = CommandType.Text;
    command.Parameters.Add("BORROWING_ID", SqlDbType.VarChar).Value = txtbox_borrow_ID.Text;
    command.CommandText = "SELECT STATUS FROM MEDREC_BORROWING WHERE BORROWING_ID = @BORROWING_ID ";
    string status  = command.ExecuteScalar().ToString();
    if (status == "Closed")
    {
        MessageBox.Show("Already closed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else
    {
        // put your stored procedure code here and call it
    }
