        public class AspNetRole
        {
          public int RoleId { get; set; }    
          public string Name { get; set; }  
           public int NewClassId{ get; set; }
           public NewClass NewClass{ get; set; }      
        }
       public class NewClass
       {
        ..................
        ................
        public ICollection<AspNetRole> AspNetRoles{ get; set; }
       }
