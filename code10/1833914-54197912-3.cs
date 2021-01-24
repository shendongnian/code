    public void stuff(Form1 form)
    {
        DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn check1 = new DataGridViewCheckBoxColumn();
        dataGridView4.ColumnCount = 1;
        dataGridView4.Columns[0].Width = 380;
        dataGridView4.Columns[0].Name = "Item";
        string[] row1 = new string[] { "Tables" };
        string[] row2 = new string[] { "Chairs" };
        string[] row3 = new string[] { "Lamps" };
        string[] row4 = new string[] { "Pillows" };
        string[] row5 = new string[] { "Blankets" };
        object[] rows = new object[] { row1, row2, row3, row4, row5 };
        object[] rows1 = new object[] { row1, row2, row3, row4 };
    
        if (form.dtgmb == false)
            foreach (string[] rowArray in rows)
            {
                this.dataGridView4.Rows.Add(rowArray);
            }
        else
            foreach (string[] rowArray in rows1)
            {
                this.dataGridView4.Rows.Add(rowArray);
            }
    
        check.HeaderText = "Pass";
        check1.HeaderText = "Fail";
        dataGridView4.Columns.Add(check);
        dataGridView4.Columns.Add(check1);
    }
