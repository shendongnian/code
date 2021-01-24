    public abstract class BaseEntity
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
    }
    
    public class Person : BaseEntity
    {
        public int PersonId { get; set; }
        public override string Name { get; set; }
    
        public override int Id
        {
            get { return PersonId; }
            set { PersonId = value; }
        }
    }
    
    public class Company : BaseEntity
    {
        public int CompanyId { get; set; }
        public override string Name { get; set; }
    
        public override int Id
        {
            get { return CompanyId; }
            set { CompanyId = value; }
        }
    }
