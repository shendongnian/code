     public override void Uninstall(IDictionary savedState)
        {
           try 
              {
                 base.Uninstall(savedState);
                 Log("Omg :O it works !");    
               }
          catch(Exception ex)
               {
                 Log(ex.Message.ToString());
               }     
        }
