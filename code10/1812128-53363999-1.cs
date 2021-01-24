    private void Button1_Click(object sender, EventArgs e)
    {
        //This is event of button click
    
        if(yourDataGridView.SelectedRows.Count < 0)
        {
            MessageBox.Show("You must select one user!");
            return;
        }
        DataGridViewRow row = yourDataGridView.SelectedRows[0]; // We will select first selected row. If there are multiple selected rows we will select just first one
        int uid = Convert.ToInt32(row.Cells["ColumnThatContainsUserId"].Value);
        string uname = row.Cells["ColumnThatContainsUserName"].Value.ToString();
        //I am using `using` since `Form` is disposable class and instead of later doing sf.Dispose() i use `using`. This way we take care of perfomance
        using(SecondForm sf = new SecondForm(uid, uname))
        {
            sf.ShowDialog();
        }
    }
