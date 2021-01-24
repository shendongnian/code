        public class AspNetRoles
       {
         public int RoleId { get; set; }  
         public string Name { get; set; }
        }
      public class NewClass
      {
       ..................
       ................
       public virtual ICollection<AspNetRoles> AspNetRole{ get; set; }
      }
 
