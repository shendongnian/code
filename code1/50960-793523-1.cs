    //Namespace References
    using System.Data;
    using System.Data.SqlClient
    
    /// <summary>
    /// Returns a DataTable, based on the command passed
    /// </summary>
    /// <param name="cmd">
    /// the SqlCommand object we wish to execute
    /// </param>
    /// <returns>
    /// a DataTable populated with the data
    /// specified in the SqlCommand object
    /// </returns>
    /// <remarks></remarks>
    
    public static DataTable GetDataTable(SqlCommand cmd)
    {
        try
        {
            // create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter();
      
            //set the SelectCommand of the adapter
            da.SelectCommand = cmd;
      
            // create a new DataTable
            DataTable dtGet = new DataTable();
      
            //fill the DataTable
            da.Fill(dtGet);
      
            //return the DataTable
            return dtGet;
          }
          catch (SqlException ex)
          {
              MessageBox.Show(ex.Message);
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }
      } 
