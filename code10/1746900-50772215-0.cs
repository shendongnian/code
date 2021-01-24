    using System;
    
    public abstract class BaseEntity
    {
        public int ID { get; protected set; }
    }
    
    public class BaseDTO
    {
        public int ID { get; protected set; }
    }
    
    public interface IRepository<out Entity, out DTO> where Entity : BaseEntity where DTO : BaseDTO
    {
     	string GetTestString();   
    }
    
    public abstract class Repository<Entity, DTO> : IRepository<Entity, DTO> 
    where Entity : BaseEntity 
    where DTO : BaseDTO
    {
     
    	// Implemented functions for IRepository Interface
    	public Repository(string connectionString)
    	{
    		
    	}
    	
    	public abstract string GetTestString();
    }
    
    public class AdministratorEntity : BaseEntity
    {
    	
    }
    
    public class AdministratorDTO : BaseDTO
    {
    	
    }
    
    public class AdministratorRepository : Repository<AdministratorEntity, AdministratorDTO>
    {
        public AdministratorRepository(string ConnectionString) : base(ConnectionString)
        {
    
        }
    	
    	public override string GetTestString()
    	{
    		return "TestString";
    	}
    
        // Implemented functions for Repository base class
    }
    
    					
    public class Program
    {
    	public static void Main()
    	{
    	
    		IRepository<BaseEntity, BaseDTO> repo = new AdministratorRepository("connectionString");
    		Console.WriteLine(repo.GetTestString());
    		Console.WriteLine("Hello World");
    	}
    }
