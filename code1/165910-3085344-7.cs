    protected void DiscontinuedCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox DiscontinuedCheckBox;
        HiddenField ProductIdHiddenField;
        DiscontinuedCheckBox = (CheckBox)sender;
        ProductIdHiddenField = (HiddenField)DiscontinuedCheckBox.Parent.FindControl("ProductIdHiddenField");
        using (conn = new SqlConnection(ProductDataSource.ConnectionString))
        {
        ...
        if (DiscontinuedCheckBox.Checked)
        {
            cmd.CommandText = "UPDATE Products SET Discontinued = 1 WHERE ProductId = " + ProductIdHiddenField.Value;
        }
        ...
        }
