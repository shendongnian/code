      foreach (DataGridItem item in dataGrid.Items)
      { 
         //...
         var data = item.Cells[0].Text;
         //or
         CheckBox chkBox = (CheckBox)item.FindControl("MyCheckBox");
         if (chkBox.Checked)
         {
             // do something
         }
      }
