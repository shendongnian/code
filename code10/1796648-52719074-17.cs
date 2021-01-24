        public class AspNetRole
       {
          public int RoleId { get; set; }    
          public string Name { get; set; }  
          public ICollection<NewClass> NewClasses{ get; set; }   
        }
      public class NewClass
      {
       ................
        public int AspNetRolesId{ get; set; }
        public AspNetRole AspNetRoles{ get; set; }
      }
 
