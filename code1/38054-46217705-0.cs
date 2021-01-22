    public DataTable ReturnSomething(out string OutputDesc)
    {
       try
          {
             //logic here
             OutputDesc = string.Format("Your Successful Message Here...");
             return ds.Tables[0];
          }
          catch (Exception e)
          {
             OutputDesc =e.Message;
             return null;
          }
    }
