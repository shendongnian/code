    using (TransactionScope scope = new TransactionScope())  
    {  
        using (myContext context = new myContext())  
        {  
            Test t = new Test()  
             t.Name="TEST";
             context.AddToTests(t);  
             context.SaveChanges();  
        }  
  
        using (myContext context = new myContext())  
        {                       
             Demo d = context.Demos.First(s => s.Name == "Demo1");  
             context.DeleteObject(d);  
             context.SaveChanges();  
        }  
        scope.Complete();  
       // also make sure you add error checking and rollback
    }   
