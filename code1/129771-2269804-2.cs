    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewComboBoxCell
                && e.Control is DataGridViewComboBoxEditingControl)
            {
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView1.CurrentCell;
                ComboBox ctrl = (ComboBox)e.Control;
                // Get Currently selected value...
                string curValue = String.Empty;
                if (cell.Value != null)
                    curValue = cell.Value.ToString();
                //bind data
                ctrl.DataSource = dataBaseData;
                //set selected value
                ctrl.SelectedItem = curValue;
            }
        }
