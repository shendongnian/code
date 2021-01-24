    private void Form1_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("col1");
        dt.Columns.Add("col2");
        for (int j = 0; j < 20; j++)
        {
            dt.Rows.Add("col1" + j.ToString(), "col2" + j.ToString());
        }
        this.dataGridView1.DataSource = dt;
        this.dataGridView1.Columns[0].Width = 150;
        this.txbtnControl = new TextAndButtonControl();
        this.txbtnControl.Visible = false;
        this.dataGridView1.Controls.Add(this.txbtnControl);
        //Handle the cellbeginEdit event to show the usercontrol in the cell while editing
        this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
    }
    TextAndButtonControl txbtnControl;
    
    void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex > -1 && e.RowIndex != this.dataGridView1.NewRowIndex)
        {
            Rectangle rect = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            this.txbtnControl.Location = rect.Location;
            this.txbtnControl.Size = rect.Size;
            this.txbtnControl.Text = this.dataGridView1.CurrentCell.Value.ToString();
            this.txbtnControl.ButtonText = "...";
            this.txbtnControl.renderControl();
            this.txbtnControl.Visible = true;
        }
    }
