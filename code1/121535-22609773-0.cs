    if (MessageBox.Show("Sure you wanna delete?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
    {
      foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
      {
          bindingSource1.RemoveAt(item.Index);
      }
          adapter.Update(ds);
     }
