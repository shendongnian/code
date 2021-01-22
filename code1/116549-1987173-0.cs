    protected void dgCategory_CellClick(object sender, DataGridViewCellEventArgs e)
    
    {
    
    //set Date Picker to false when initially click on cell
    
          if (dtPicker.Visible)
              dtPicker.Visible = false;
          if (e.ColumnIndex == 2)
          {
          //set date picker for category datagrid
             dtPicker.Size = dgCategory.CurrentCell.Size;
             dtPicker.Top = dgCategory.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Top;
             dtPicker.Left = dgCategory.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Left;
    
             if (!(object.Equals(Convert.ToString(dgCategory.CurrentCell.Value), "")))
                 dtPicker.Value = Convert.ToDateTime(dgCategory.CurrentCell.Value);
             dtPicker.Visible = true;
    
          }
    }
    
    private void dtPicker_ValueChanged(object sender, EventArgs e)
    {
          dgCategory.CurrentCell.Value = dtPicker.Value;
          dtPicker.Visible = false;
    
    }
