     try
     {
         Push(null);
     }
     catch (InvalidOperationException ioex)
     {
         MessageBox.Show(ioex.Message);
     }
     catch (Exception ex)
     {
         // Unhandled exception
         MessageBox.Show(ex.Message);
     }
