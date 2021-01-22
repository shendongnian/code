        DataGridView _lastDataGridView = null;
        private void dataGridView_Leave(object sender, EventArgs e)
        {
            _lastDataGridView = sender as DataGridView;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (_lastDataGridView != null)
            {
                // check if data needs saving...
            }
        }
