      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        selectedStockDescription = dgv_StckSrchRes.Rows[e.RowIndex].Cells[1].Value.ToString();
        selectedStockCode = dgv_StckSrchRes.Rows[e.RowIndex].Cells[0].Value.ToString();
        DialogResult result = MessageBox.Show(
          (selectedStockDescription), 
          "Add this item to the order?", 
           MessageBoxButtons.YesNoCancel, 
           MessageBoxIcon.Question);
        if (result == DialogResult.Yes) {
          stockCode = selectedStockCode;
          stockDescription = selectedStockDescription;
          //    this.Close();                                
          this.DialogResult = DialogResult.OK; // <- not Close with cancel
        }
        else if (result == DialogResult.No) { // <- typo? 
          this.Focus();
        else if (result == DialogResult.Cancel) {
          this.Close(); // <- Close with DialogResult.Cancel
        }
          ...
