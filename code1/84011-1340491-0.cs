    foreach (GridViewRow gridViewRow in GridAvailableUsers.Rows)
                {
                    // only add selected topics.
                    CheckBox selCheckBox = (CheckBox)gridViewRow.Cells[3].Controls[1];
                    if (selCheckBox.Checked)
                    {
    // do something
                    }
                }
