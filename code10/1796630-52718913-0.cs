    public class AspNetRoles
    {
        public int RoleId { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName{ get; set; }
    
        public List<NewClass> NewClasses{ get; set; }
    }
    
    public class NewClass
    {
       public string Name { get; set; }
    
       public int Type { get; set; }
    
       public int RoleId { get; set; }
       public AspNetRoles AspNetRole{ get; set; }
    }
