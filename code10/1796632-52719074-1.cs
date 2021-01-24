        public class AspNetRoles
        {
         public int RoleId { get; set; }
    
          public string Name { get; set; }
           
          public ICollection<NewClass> NewClasses{ get; set; }
        }
       public class NewClass
       {
        ..................
        ................
        public ICollection<AspNetRoles> AspNetRole{ get; set; }
       }
