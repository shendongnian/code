    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (!(e.Control is DataGridViewTextBoxEditingControl)) return;
        TextBoxBase editControl = (TextBoxBase)e.Control;
        var cellText = editControl.Text;
        if (cellText?.Length > 1)
        {
            BeginInvoke(new Action(() => {
                string word = cellText.Split().Last();
                editControl.Select(cellText.Length - word.Length, word.Length);
            }));
        }
    }
