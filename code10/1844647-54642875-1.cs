    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
        {
            bool checkVal = (Boolean)dataGridView1.CurrentCell.EditedFormattedValue;       // Check box state value
            int checkBoxState = checkVal ? 1 : 0;       // 1 - TRUE, 0 - FALSE
            // Now save the check box state change in the database table.
            // You would need a key field to distinguish the record in the DB table
            // As per the code you had provided you could do something similar to below, assuming that the Pno column is the key field/ unique
            int keyValue = (int)dataGridView1.CurrentRow.Cells["Pno"].Value;
            // Save the changes by passing checkBoxState and keyValue accordingly
            SetNewUploadFileForGrantAppID(checkBoxState, keyValue);
        }
    }
