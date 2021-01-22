    foreach (DataGridViewRow row in this.dataGridView2.Rows)
    {
       DataGridViewCell cell = row.Cells["foo"];//Note specified column NAME
       {
          if (cell != null && (cell.Value != null || !cell.Value.Equals("")))
          {
             GetQuestions(cell.Value.ToString());
          }
       }
    }
