    public abstract class Entity
    {
    	public int Id { get; set; }
    }
    public class Distributor : Entity
    {	
    	public User User { get; set; }
    
    	public int UserId { get; set; }
    
    	public Address Address { get; set; }
    
    	public int AddressId { get; set; }
    
    	public ICollection<DistributorManufactorer> DistributorManufactorers { get; set; }
    }
    
    public class Manufacturer : Entity
    {
    	public Address Address { get; set; }
    
    	public int AddressId { get; set; }
    
    	public ICollection<DistributorManufactorer> DistributorManufactorers { get; set; }
    }
    
    public class DistributorManufactorer
    {
    	public Distributor Distributor { get; set; }
    
    	public int DistributorId { get; set; }
    
    	public Manufacturer Manufacturer { get; set; }
    
    	public int ManufacturerId { get; set; }
    }
