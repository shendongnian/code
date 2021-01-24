    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is DataGridViewTextBoxEditingControl tbec)
        {
            var cellText = tbec.Text;
            if (cellText?.Length > 1)
            {
                BeginInvoke(new Action(() => {
                    string word = cellText.Split().Last();
                    tbec.Select(cellText.Length - word.Length, word.Length);
                }));
            }
        }
    }
