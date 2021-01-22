    public static String[] List{
       get{
          return _List.ToArray();
       }
    } 
    
    //While using ...
    
    String[] values = Class1.List;
    
    foreach(string v in values){
      ...
    }
    
    // instead of calling foreach(string v in Class1.List)
    // again and again, values in this context will not be
    // duplicated, however values are cached instance so 
    // immediate changes will not be available, but its
    // thread safe
    foreach(string v in values){
      ...
    }
