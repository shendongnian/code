    bool bSomeFlag = false;
    int iCol = 0;
    int iRow = 0;
    private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e) {
                iCol = e.ColumnIndex;
                iRow = e.RowIndex;
                bSomeFlag = true;
                this.dataGridView1.Invalidate();
            }
    private void dataGridView1_Paint(object sender, PaintEventArgs e) {
                if (bSomeFlag && iRow >=0 && iCol>=0) {
                    dataGridView1.Rows[iRow].Cells[iCol].Style.BackColor = Color.Red;
                }
            }
