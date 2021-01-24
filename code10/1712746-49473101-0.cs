    //Collect the values in the TextBoxes in a string array
    private void button1_Click(object sender, EventArgs e)
    {
        string[] Ranges = new string[] { tbStarting.Text.Trim(), tbEnding.Text.Trim() };
    
        if (xDataSet != null)
            FilterDataset(Ranges);
    }
    private void FilterDataset(string[] Ranges)
    {
        if (string.IsNullOrEmpty(Ranges[0]) & string.IsNullOrEmpty(Ranges[1]))
            xDataSet.Tables[0].DefaultView.RowFilter = null;
        else if (string.IsNullOrEmpty(Ranges[0]) | string.IsNullOrEmpty(Ranges[1]))
            return;
        else if (int.Parse(Ranges[0]) < int.Parse(Ranges[1]))
            xDataSet.Tables[0].DefaultView.RowFilter = string.Format("SrNo >= {0} AND SrNo <= {1}", Ranges[0], Ranges[1]);
        else
            xDataSet.Tables[0].DefaultView.RowFilter = string.Format("SrNo = {0}", Ranges[0]);
        this.dataGridView1.Update();
    }
