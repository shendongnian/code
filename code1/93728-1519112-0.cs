    01.    using (DataContext db = new DataContext())
    02.    {    
    03.        db.Connection.Open();    
    04.        db.Transaction = db.Connection.BeginTransaction();    
    05.
    06.        foreach (string entry in entries)        
    07.        {                
    08.            XXX xxx = new XXX()                
    09.            {                        
    10.                P1 = "something",                        
    11.                P2 = "something"                
    12.            };                
    13.            db.XXXX.InsertOnSubmit(xxx);                
    14.            db.SubmitChanges();        
    15.        }    
    16.
    17.        db.Transaction.Commit();
    18.    }
