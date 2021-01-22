    private void dataGridView1_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
    {
        dataGridView1.Rows[e.RowIndex].ErrorText = "";
        int newInteger;
        if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
        if (!int.TryParse(e.FormattedValue.ToString(),
            out newInteger) || newInteger < 0)
        {
            e.Cancel = true;
            dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
            //If it's simple, do something like this here.
            this.SubmitButton.Enabled = false;
            //If not, set a private boolean variable scoped to your class that you can use elsewhere.
            this.PassedValidation = false;
        }
    }
