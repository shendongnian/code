    public DataTable ReturnSomething(out string errorString)
    {
       errorString = string.Empty;
       DataTable dt = new DataTable();
       try
       {  
          //logic here
         dt = ds.Tables[0];
       }
       catch (Exception e)
       {
          errorString = e.Message;
       }
       return dt;
    }
