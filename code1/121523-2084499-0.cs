     private void btnDelete_Click(object sender, EventArgs e)
     {
         foreach (var item in this.dataGridView1.SelectedRows)
         {
             dataGridView1.Rows.RemoveAt(item.Index);
         }
     }
