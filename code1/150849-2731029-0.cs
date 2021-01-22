        Class SomeClass        
        {
         string name;
         string Name 
         { 
           set 
           {
            if (name  == null) 
             name  = value; 
           }
         }
       }
