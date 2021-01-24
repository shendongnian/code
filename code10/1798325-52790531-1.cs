    protected void UsersGrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        ((DataControlField)UsersGrid.Columns
                .Cast<DataControlField>()
                .Where(fld => fld.HeaderText == "Email")
                .SingleOrDefault()).Visible = false;
    }
