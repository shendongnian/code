    try
    {
         SaveData();
    }
    catch (Exception ex)
    {
         var sqlException = ex.InnerException as System.Data.SqlClient.SqlException;
         if (sqlException.Number == 2601)
         {
             MessageBox.show("Product Already Exists");
         }
         else
         {
             MessageBox.show(ex.Message());
         }
    }
