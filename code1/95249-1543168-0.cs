        catch (Exception ex)
        {
    System.Data.OracleClient.OracleException oEx = (System.Data.OracleClient.OracleException)ex.InnerException;
            
          if (oEx.Message.IndexOf("ORA-0054") != 0)
          {
             .... do something here...    
          }
