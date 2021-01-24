    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        var caseDictionary = new Dictionary<Func<bool>, Action>()
        {
            { () => (e.ColumnIndex == dataGridView1.Columns["First"].Index), () => {  MessageBox.Show("First");}},
            { () => (e.ColumnIndex == dataGridView1.Columns["Second"].Index), () => { MessageBox.Show("Second");}},
            { () => (e.ColumnIndex == dataGridView1.Columns["Third"].Index), () => { MessageBox.Show("Third");}}
        };
        caseDictionary.Where(caseRecord => caseRecord.Key()).Select(action => action.Value).FirstOrDefault()?.Invoke();
    }
