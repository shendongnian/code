    if (e.RowIndex != -1)
    {
        DataGridViewRow dr = dataGridView1.CurrentRow;
        DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)dr.Cells[3];
                
        try 
        {
            if ((bool)chkCell.Value == true)
            {
                DialogResult dResult = MessageBox.Show("Do you want to unmark this value!", "Delete", MessageBoxButtons.YesNo);
                if (dResult == DialogResult.Yes)
                {
                    chkCell.Value = false;
                }
                else
                {
                    dataGridView1.EndEdit();
                    chkCell.Value = true;
                }
            }
            else if ((bool)chkCell.Value == false)
            {
                DialogResult dResult = MessageBox.Show("Do you want to mark this value for deletion?", "Delete", MessageBoxButtons.YesNo);
                if (dResult == DialogResult.Yes)
                {
                    chkCell.Value = true;
                }
                    else if (dResult == DialogResult.No)
                {
                    dataGridView1.EndEdit();
                    chkCell.Value = false;
                }
            }
        }
        catch (Exception)
        {
            DialogResult dResult = MessageBox.Show("Do you want to mark this value for deletion?", "Delete", MessageBoxButtons.YesNoCancel);
            if (dResult == DialogResult.Yes)
            {
                chkCell.Value = true;
            }
            else if (dResult == DialogResult.No)
            {
                chkCell.Value = true;
            }
            else if (dResult == DialogResult.Cancel)
            {
                dataGridView1.EndEdit();
                chkCell.Value = false;
            }
        }
    }
    dataGridView1.EndEdit();
