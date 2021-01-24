           // Call this in your event.
         If(NoRowOrNoDuplicate())
       {   
        dgvOC.Rows.Add(txtProd.Text, numCant.Value, txtTipo.Text, precioGuardado, precioGuardado * (int)numCant.Value);
           }
  
      //The method be like
        private bool NoRowOrNoDuplicate()
                {
                 // Add condition s here
               for (int i = 0; i <= dgvOC.Rows.Count; i++)
                 {
                        if (txtProd.Text == dgvOC.Rows[i].Cells[0].Value.ToString())
                          {
            MessageBox.Show("Usted ya ha agregado un producto con el mismo nombre" +
            ", modifique la cantidad o borre el producto para agregarlo" +
            " de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       txtProd.Clear();
                       txtTipo.Clear();
                       numCant.Value = 0;
                       return false;
                        }
                       }
                Return true;
                 }
   
