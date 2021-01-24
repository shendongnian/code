    Public class AspNetRole
    {
        //Other property
        public int UserId { get; set; }
    }
    
    public class User
    {
        //Other property
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
        public virtual ICollection<NewClass> NewClasses { get; set; }
    }
    public class NewClass
    {
        //Other property
        public int AspNetRoleId { get; set; }
    }
