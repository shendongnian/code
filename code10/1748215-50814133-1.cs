    protected void Button1_Click(object sender, EventArgs e)
    {
        List<DataGridViewRow> CountRows = new List<DataGridViewRow>();
        for (int i = this.GridView1.Rows.Count-1; CountRows.Count < 2 || i >= 0; i--)
        {
            if ((double)this.GridView1.Rows[i].Cells[2].Value != 0)
            {
                CountRows.Add(this.GridView1.Rows[i]);
            }
        }
        if(CountRows.Count >= 1)
        {
            lblValue1.Text = "Value1:" + CountRows[0].Cells[0].Text;
        }
        if(CountRows.Count == 2)
        {
            lblValue2.Text = "Value2:" + CountRows[1].Cells[0].Text;
        }
    }
