    public class Person
    {
       public string Name { get; set; }  
    
       private List<Role> _roles = null;
       public IEnumerable<Role> Roles 
       {
          get { 
            if (_roles != null) 
              return _roles;
            else
              return Enumerable.Empty<Role>();
            }
       }
    }
