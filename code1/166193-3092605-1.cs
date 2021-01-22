    class Role
    {
         public Person Contributor { ... } 
         public Movie  Feature { ... }
         public RoleType Activity { ... }
    }  
        
    class Person
    {
        public List<Role> Contributions { ... }
    }        
    
    class Movie
    {
        public List<Role> Contributors { ... }
        ...
    }
