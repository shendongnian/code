    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
          if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl)) {
            DataGridViewComboBoxEditingControl edit = e.Control as DataGridViewComboBoxEditingControl;
            edit.DropDownStyle = ComboBoxStyle.DropDown;
          }
        }
