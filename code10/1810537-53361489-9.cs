    public interface IBaseEntity
    {
        DateTime LastDateModified { get; set; }
        string LastDateModifiedBy { get; set; }
        DateTime DateCreated { get; set; }
        string DateCreatedBy { get; set; }
    }
    public class Host : IBaseEntity
    {
        // the other fields
        // ...
        public DateTime LastDateModified { get; set; }
        public string LastDateModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string DateCreatedBy { get; set; }
    }
