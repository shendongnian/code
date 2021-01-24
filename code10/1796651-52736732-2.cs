    Public class AspNetRole
    {
        //Other property
        public int NewClassId { get; set; }
    }
    
    public class NewClass
    {
        //Other property
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
