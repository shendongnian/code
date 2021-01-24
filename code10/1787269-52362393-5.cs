    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // This will write the changes to the BindingSource 
        // and automatically update the DataGridView
        tbFirstName.DataBindings["Text"]?.WriteValue();
        tbLastName.DataBindings["Text"]?.WriteValue();
        tbEmail.DataBindings["Text"]?.WriteValue();
    }
