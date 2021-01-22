    DataGridViewCheckBoxCell checkedCell = (DataGridViewCheckBoxCell) grdData.Rows[e.RowIndex].Cells["grdChkEnable"];
        
                    bool isEnabled = false;
                    if (checkedCell.AccessibilityObject.State.HasFlag(AccessibleStates.Checked))
                    {
                        isEnabled = true;
                    }
    if(isEnabled)
     {
       // do your business process;
     }
