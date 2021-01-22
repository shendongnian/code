    private DataRowView rowBeingEdited = null;
        public void UpdateQueueData(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                rowBeingEdited = null;
                DataRowView rowView = e.Row.Item as DataRowView;
                rowBeingEdited = rowView;
            }
        }
        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (rowBeingEdited != null)
            {
                rowBeingEdited.EndEdit();
                Queue = ((DataView)dataGridQueue.ItemsSource).ToTable();
                WriteXML();
                loadQueue();
            }
        }
