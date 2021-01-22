    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
       if (dataGridView1.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
       {
          dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
       }
    }
