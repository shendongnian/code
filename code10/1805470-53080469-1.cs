    public GraspForm()
    {
        InitializeComponent();
        this.dgvRecords.CellValueChanged += new DataGridViewCellEventHandler(dgvCellValueChanged);
    }
    private void dgvCellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if(e.ColumnIndex == 1)
        {
            var currentRow = this.dgvRecords.Rows[e.RowIndex];
            if(currentRow.Cells[0].Value != null && currentRow.Cells[1].Value != null)
            {
                var val1 = currentRow.Cells[0].Value.ToString();
                var val2 = currentRow.Cells[1].Value.ToString();
                this.dgvRecords.Rows[e.RowIndex].Cells[2].Value = CalculateTotal(val1, val2);
            }
        }
    }
