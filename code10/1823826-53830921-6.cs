    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        if(e.ColumnIndex == 0)
        {
            Form2 f = new Form2();
            var result = f.ShowDialog();
            if(result == DialogResult.OK)
            {
                List<Person> selection = new List<Person>();
                f.GetSelection(selection);
                BindingSource bs = new BindingSource();
                bs.DataSource = selection;
                dataGridView1.DataSource = bs;
            }
            f.Dispose();
        }
    }
