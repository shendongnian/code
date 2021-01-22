    public interface IEntity
    {
    
    }
        
    public class Employee : IEntity
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public int EmployeeID { get; set; }
    }
        
    public class Company : IEntity
    {
    	public string Name { get; set; }
    	public string TaxID { get; set }
    }
        
    public class DataService<ENTITY, DATACONTEXT>
    	where ENTITY : class, IEntity, new()
    	where DATACONTEXT : DataContext, new()
    {
        
    	public void Create(List<ENTITY> entities)
    	{
    		using (DATACONTEXT db = new DATACONTEXT())
    		{
    			Table<ENTITY> table = db.GetTable<ENTITY>();
        
    			foreach (ENTITY entity in entities)
    				table.InsertOnSubmit (entity);
        
    			db.SubmitChanges();
    		}
    	}
    }
        
    public class MyTest
    {
    	public void DoSomething()
    	{
    		var dataService = new DataService<Employee, MyDataContext>();
    		dataService.Create(new Employee { FirstName = "Bob", LastName = "Smith", EmployeeID = 5 });
    		var otherDataService = new DataService<Company, MyDataContext>();
                otherDataService.Create(new Company { Name = "ACME", TaxID = "123-111-2233" });
    
    	}
    }
