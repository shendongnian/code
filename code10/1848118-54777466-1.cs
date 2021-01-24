    private async void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (!(e.Control is DataGridViewTextBoxEditingControl)) return;
        await Task.Delay(10);
        TextBoxBase editControl = (TextBoxBase)e.Control;
        var cellText = editControl.Text;
        if (cellText?.Length > 1)
        {
            string word = cellText.Split().Last();
            editControl.Select(cellText.Length - word.Length, word.Length);
        }
    }
