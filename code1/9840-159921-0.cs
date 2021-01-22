     public class MyClass : IDisposable
      { Database db
        public MyClass()  { db = new Database();}
        public int Id 
         { get { if (_id == null) _id = db.GetIdFor(typeof(MyClass)); 
                 return _id.Value;     
               }
         } int? _id;
        IDisposable.Dispose() { db.Close(); } 
     }
    using (var x = new MyClass()) 
     { /* ... */
     } //closes DB
        
        
