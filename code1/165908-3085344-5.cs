    protected void DiscontinuedCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox DiscontinuedCheckBox;
        SqlConnection conn;
        SqlCommand cmd;
        int productId;
        GridViewRow selectedRow;
        // Cast the sender object to a CheckBox
        DiscontinuedCheckBox = (CheckBox)sender;
        // We can find the row we clicked the checkbox in by walking up the control tree
        selectedRow = (GridViewRow)DiscontinuedCheckBox.Parent.Parent;
        // GridViewRow has a DataItemIndex property which we can use to look up the DataKeys array
        productId = (int)ProductGridView.DataKeys[selectedRow.DataItemIndex].Value;
        using (conn = new SqlConnection(ProductDataSource.ConnectionString))
        {
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            if (DiscontinuedCheckBox.Checked)
            {
                cmd.CommandText = "UPDATE Products SET Discontinued = 1 WHERE ProductId = " + ProductId.ToString();
            }
            else
            {
                cmd.CommandText = "UPDATE Products SET Discontinued = 0 WHERE ProductId = " + ProductId.ToString();
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
