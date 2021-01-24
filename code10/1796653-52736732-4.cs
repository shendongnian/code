    Public class AspNetRole
    {
        //Other property
        public int UserId { get; set; }
    }
    
    public class User
    {
        //Other property
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
