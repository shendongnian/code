    public class Country
    {
    	public int ID{get; set;}
    	public string CountryName{get; set;}
    	public List<Company> Items{get; set;}
    	
    	public int SaveOrUpdate(){}
    	public static Country Get(int id){}
    	public static List<Country> Get(){}
    	public bool Delete(){}
    }
    
    public class Company
    {
    	public int ID {get; set;}
    	public string CompanyName{get; set;}
    	public int CountryID{get; set;}
    	public Country Country{get; set;}
    	
    	public int SaveOrUpdate() {}
    	public static Company Get(int id) {}
    	public static List<Company> Get(){}
    	public bool Delete() {}	
    }
    
   
