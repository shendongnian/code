     CheckBox chkSelect = (CheckBox)e.Row.Cells[CheckBoxColumnIndex].FindControl(InputCheckBoxField.CheckBoxID);
          if (chkSelect != null)
          {
               Guid selectedValue = new Guid(DataKeys[e.Row.RowIndex].Value.ToString());
               chkSelect.Checked = SelectedValues.Contains(selectedValue);
               chkSelect.CheckedChanged += new EventHandler(CheckChanged_click);
          }
