     using (ClassContext context = new ClassContext()){
           ((IObjectContextAdapter)context).ObjectContext.Connection.Open();
             
            //SOMETHING TO DO......
           ((IObjectContextAdapter)context).ObjectContext.Connection.Close(); 
     }
