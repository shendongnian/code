     CheckBox chkSelect = (CheckBox)e.Row.Cells[CheckBoxColumnIndex].FindControl(InputCheckBoxField.CheckBoxID);
    
          if (chkSelect != null)
          {
                chkSelect.CheckedChanged += new EventHandler(CheckChanged_click);
                Guid selectedValue = new Guid(DataKeys[e.Row.RowIndex].Value.ToString());
                chkSelect.Checked = SelectedValues.Contains(selectedValue);
          }
    
    // if your done with chkSelect
    chkSelect.CheckedChanged -= CheckChanged_click;
