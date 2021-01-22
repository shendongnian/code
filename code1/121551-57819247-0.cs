    private void btnDelete_Click(object sender, EventArgs e)
    {
        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    ?BindingSource.EndEdit();
                    ?TableAdapter.Update(this.?DataSet.yourTableName);
    }
    
    //NOTE:
    //? - is your data from database
