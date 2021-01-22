    using  (TransactionScope scope = new TransactionScope()){
       var maxId = dc.Logs.Max(s => s.ID); 
       var newEntity = new Log(){        
           ID = maxId,        
           Note = "Test"           
       };
       dc.Logs.InsertOnSubmit(newEntity);
       dc.SubmitChanges();
       scope.Complete();
    }  
