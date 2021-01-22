    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
                if (selectAllToolStripMenuItem.Checked)
                    selectAllToolStripMenuItem.Checked = false;
    
                if (dtPicker.Visible)
                    dtPicker.Visible = false;
    
                if (e.ColumnIndex >= 0)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        if (adminIsLoggedIn)
                        {
                            removeRow(e);
                        }
                        else
                        {
                            MessageBox.Show("You must be logged in as an Administrator in order to change the facility configuration.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name == "TIMESTAMP")
                    {
                        if (adminIsLoggedIn)
                        {
                            setNewCellDate(e);
                        }
                    }
                    .....
                }
                // ---
}
    private void setNewCellDate(DataGridViewCellEventArgs e)
    {
                dtPicker.Size = dataGridView1.CurrentCell.Size;
                dtPicker.Top = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Top + dataGridView1.Top;
                dtPicker.Left = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Left + dataGridView1.Left;
                if (!(object.Equals(Convert.ToString(dataGridView1.CurrentCell.Value), "")))
                    dtPicker.Value = Convert.ToDateTime(dataGridView1.CurrentCell.Value);
                dtPicker.Visible = true;
    }
