    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public int RoleId { get; set; }
        public Role Role { get; set; }
        
    }
