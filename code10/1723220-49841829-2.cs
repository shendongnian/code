    public class Person : Entity
    {
    	public virtual ICollection<PersonEntity> PersonCompanies { get; private set; }
    	public virtual ICollection<PersonEntity> CompanyPersons { get; private set; }
    }
