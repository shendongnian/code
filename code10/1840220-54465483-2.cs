    foreach (DataGridViewRow row in computerSelection.compGridView.Rows)
            {
                // Don't cast as bool. Convert to Checkbox object and see if it is checked. 
                if (((CheckBox)row.FindControl("CheckBox")).Checked) // row.FindControl might be different but might be the same for Winforms.
                {
                    computerSelection.ComputersList.Add(row.Cells[1].Value.ToString());
                }
            }
 
