      string ColId   = "1"; //Set The Column Name to read
      Int32  Row     = 2; //Set the Row to Read
      Matrix oMatrix =(Matrix)SBO_Application.Forms.ActiveForm.Items.Item("38").Specific; //Get Access to the Matrix
      EditText oEdit =(EditText)oMatrix.Columns.Item(ColId).Cells.Item(Row).Specific; //Cast the Cell of the matrix to the respective type , in this case EditText
      string sValue  = oEdit.Value; //Get the value form the EditText
