    private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
    {
	    if (Char.IsLetter(e.KeyChar))
        {
            int index = 0;
            // This works only if dataGridView1's SelectionMode property is set to FullRowSelect
            if (dataGridView1.SelectedRows.Count > 0 )
            {
                index = dataGridView1.SelectedRows[0].Index + 1
            }
            for (int i = index; i < (dataGridView1.Rows.Count + index); i++)
    	    {
    		    if (dataGridView1.Rows[i % dataGridView1.Rows.Count].Cells["Name"].Value.ToString().StartsWith(e.KeyChar.ToString(), true, CultureInfo.InvariantCulture))
    		    {
                    foreach (var row in dataGridView1.Rows.Cast<DataGridViewRow>().Where(t => t.Selected))
                    {
                        row.Selected = false;
                    }
    			    dataGridView1.Rows[i % dataGridView1.Rows.Count].Cells[0].Selected = true;
    			    return; // stop looping
    		    }
    	    }
        }
    }
