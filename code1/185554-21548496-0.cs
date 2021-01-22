    private void gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string cellHeader = gridView.Columns[e.ColumnIndex].HeaderText.ToString();
           
           //if cell is one that needs validating
           if (cellHeader == "Something" || cellHeader == "Something Else")
           {
               //if it isn't null/empty
               if (gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null
                   && gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
               {
                   //check if it's valid (here using REGEX to check if it's a number)                  
                   if (System.Text.RegularExpressions.Regex.IsMatch(gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), @"^(?:^\d+$|)$"))
                   {
                       //set the relevant boolean if the value to true if the cell it passes validation
                       switch (cellHeader)
                       {
                           case "Something":
                               validation1_valid= true;
                               break;
                           case "Something Else":
                               validation2_valid= true;
                               break;
                       }
                       //Add an error text
                       gridView.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.Black;
                       gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = String.Empty;
                       gridView.Rows[e.RowIndex].ErrorText = String.Empty;
                       
                       //DON'T disable the button here - it will get changed every time the validation is called
                   }
                   else //doesn't pass validation
                   {
                       //set boolean to false
                       switch (cellHeader)
                       {
                           case "Something":
                               validation1_valid = false;
                               break;
                           case "Something Else":
                               validation2_valid = false;
                               break;
                       }
                       gridView.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.Red;
                       gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Value must be numeric.";
                    }
               }
               else //null or empty - I'm allowing these, so set error to "" and booleans to true
               {
                   switch (cellHeader)
                       {
                           case "Something":
                               validation1_valid = true;
                               break;
                           case "Something Else":
                               validation2_valid = true;
                               break;
                       }
                   gridView.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.Black;
                   gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = String.Empty;
                   gridView.Rows[e.RowIndex].ErrorText = String.Empty;
               }
           }
           //if there is an invalid field somewhere
           if (validation1_valid == false || validation2_valid == false)
           {
               //set the button to false, and add an error to the row
               btnSave.Enabled = false;
               gridView.Rows[e.RowIndex].ErrorText = "There are validation errors.";
           }
           //else if they're all vaild
           else if (validation1_valid == true && validation2_valid == true)
           {
               //set the button to true, and remove the error from the row
               btnSave.Enabled = true;
               gridView.Rows[e.RowIndex].ErrorText = String.Empty;
           }
        }
