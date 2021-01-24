    public interface IItem
    {
    	string Name {get;set;}
    	string Modal {get;set;}
    	long Power {get;set;}
    }
    
    public class Car : IItem
    {
    	public Car(string name, string modal, long power)
    	{
    		this.Name = name;
    		this.Modal = modal;
    		this.Power = power;
    	}
    	
    	public string Name {get;set;}
    	public string Modal {get;set;}
    	public long Power {get;set;}
    }
    
    public class Plane : IItem
    {
    	public Plane(string name, string modal, long power)
    	{
    		this.Name = name;
    		this.Modal = modal;
    		this.Power = power;
    	}
    	
    	public string Name {get;set;}
    	public string Modal {get;set;}
    	public long Power {get;set;}
    }
    
    public class InventoryItem
    {
    	public InventoryItem(IItem item, int quantity)
    	{
    		this.Item = item;
    		this.Quantity = quantity;
    	}
    	
    	public IItem Item {get;set;}
    	public int Quantity {get;set;}
    }
    
    public class Company
    {
    	public Company(string name, string country)
    	{
    		this.Name = name;
    		this.Country = country;
    	}
    	
    	public string Country {get;set;}
    	public string Name {get;set;}
    }
