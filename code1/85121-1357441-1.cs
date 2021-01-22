        private void HandleEditShowing(
            object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var cbo = e.Control as ComboBox;
            if (cbo == null)
            {
                return;
            }
            cbo.DropDownStyle = ComboBoxStyle.DropDown;
            cbo.Validating -= HandleComboBoxValidating;
            cbo.Validating += HandleComboBoxValidating;
        }
        private void HandleComboBoxValidating(object sender, CancelEventArgs e)
        {
            var combo = sender as DataGridViewComboBoxEditingControl;
            if (combo == null)
            {
                return;
            }
            //check if item is already in drop down, if not, add it to all
            if (!combo.Items.Contains(combo.Text))
            {
                var comboColumn = this.dataGridView1.Columns[
                    this.dataGridView1.CurrentCell.ColumnIndex] as
                        DataGridViewComboBoxColumn;
                combo.Items.Add(combo.Text);
                comboColumn.Items.Add(combo.Text);
                this.dataGridView1.CurrentCell.Value = combo.Text;
            }
        }
