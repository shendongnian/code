    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
     if (e.RowIndex > 0) //this might change for you depending on your header
     {
      if (dataGridView1.SelectedCells[0].GetType().Name = "DataGridViewComboBoxCell")
       {
        dataGridView1.BeginEdit(true);
        ComboBox comboBox = (ComboBox)dataGridView1.EditingControl;
        comboBox.DroppedDown = true;
        }
     }
    }
