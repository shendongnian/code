    dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        CommonClickBehaviour(e.RowIndex);
    }
    btnNext_Click(object sender, EventArgs e) {
        if ((dataGridView.CurrentRow.Index + 1) < dataGridView.Rows.Count)
            CommonClickBehaviour(dataGridView.CurrentRow.Index + 1);
    }
    void CommonClickBehaviour(int rowIndex) {
        // respond to the event or psuedo-event here.
    }
