    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateTable();
    }
    public void GenerateTable()
    {
        int i = 0;
        bool[] box = {true, false, true, false, true};
        List<TableRow> tRows = new List<TableRow>();
        TableRow newRow = new TableRow();
        tRows.Add(newRow);
        foreach (var check in box)
        {
            TableCell tempCell = new TableCell();
            CheckBox c = new CheckBox { ID = "chk"  + i };
            c.Checked = check;
            tempCell.Controls.Add(c);                    
            
            tRows[0].Cells.Add(tempCell);
            i++;
        }
        foreach (TableRow row in tRows)
        {
            myTable.Rows.Add(row);
        }
    }
    public void TEST_Click(object sender, EventArgs e)
    {
        CheckBox chkbox = (CheckBox)this.myTable.FindControl("chk1");
        if (chkbox != null)
        {
            if (!chkbox.Checked)
            {
                MessageBox.Show("Checked");
            }
            else
            {
                MessageBox.Show("NOT Checked");
            }
        }
        else 
        {           
            MessageBox.Show("NOTHING :(");                           
        }
    }                     
