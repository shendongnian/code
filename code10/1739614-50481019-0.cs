    private void DataGridView1_EditingControlShowing(object sender,
        DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex == 4)
        {
            var txt = (TextBox)e.Control;
            txt.Text = $"{dataGridView1.CurrentCell.Value}";
            txt.UseSystemPasswordChar = true;
        }
    }
