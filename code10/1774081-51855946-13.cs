      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        selectedStockDescription = dgv_StckSrchRes.Rows[e.RowIndex].Cells[1].Value.ToString();
        selectedStockCode = dgv_StckSrchRes.Rows[e.RowIndex].Cells[0].Value.ToString();
        DialogResult result = MessageBox.Show(
          (selectedStockDescription), 
          "Add this item to the order?", 
           MessageBoxButtons.YesNoCancel, 
           MessageBoxIcon.Question);
        if (result == DialogResult.Yes) {
          // Confirmed: close form WITH the choice
          stockCode = selectedStockCode;
          stockDescription = selectedStockDescription;
          // this.Close();                     // <- cause of the misbehaviour           
          this.DialogResult = DialogResult.OK; // <- not Close (with cancel) but with OK
        }
        else if (result == DialogResult.No)  
          // Not confirmed: keep on selecting 
          this.Focus();
        else // no need in "if": all the rest is Cancel 
          // Cancellation: close the form WITHOUT choice 
          this.Close(); // <- Close with DialogResult.Cancel
      }
