    public void writeCSV(DataGridView gridIn, string outputFile) {
       try {
         using (StreamWriter swOut = new StreamWriter(outputFile)) {
           //write header rows to csv
           for (int i = 0; i < gridIn.Columns.Count; i++) {
             swOut.Write(gridIn.Columns[i].HeaderText);
             if (i < gridIn.ColumnCount - 1) {
               swOut.Write(",");
             }
             else {
               swOut.WriteLine();
             }
           }
           //write DataGridView rows to csv
           for (int row = 0; row < gridIn.Rows.Count; row++) {
             if (!gridIn.Rows[row].IsNewRow) {
               for (int col = 0; col < gridIn.Columns.Count; col++) {
                 if (dataGridView1.Rows[row].Cells[col].Value != null) {
                   swOut.Write(dataGridView1.Rows[row].Cells[col].Value.ToString());
                 }
                 else {
                   swOut.Write("");
                 }
                 if (col < gridIn.Columns.Count - 1) {
                   swOut.Write(",");
                 }
                 else {
                   swOut.WriteLine();
                 }
               }
             }
           }
         }
       }
       catch (Exception e) {
          MessageBox.Show("Error: " + e.Message);
       }
     }
