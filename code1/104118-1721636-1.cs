    protected void sqlDataSource_Updated(object sender, SqlDataSourceStatusEventArgs e)
    
    {
      
           if (e.Exception != null)
                {
                    // If so, checks the Exception message
                    if (e.Exception.Message == "record already exists")
                    {
                    }
             }
    }
