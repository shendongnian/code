    Public class AspNetRole
    {
        //Other property
        public virtual ICollection<NewClass> NewClasses { get; set; }
    }
    
    public class NewClass
    {
        //Other property
        public int AspNetRoleId { get; set; }
    }
