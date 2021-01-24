    void Main()
    {
    	var sm = new StockMarket();
    	sm.Companies.Add(new Company("Test", "TST", 50, 0));
    	sm.UpdatePrice("Test", 45);
    	var testCompany = sm.Companies.First(x => x.Name == "Test");
    	Console.WriteLine($"{testCompany.Name},{testCompany.Symbol},{testCompany.Price},{testCompany.Change}");
    	//Output: Test,TST,45,-5
    }
    
    class StockMarket
    {
    	public List<Company> Companies { get; private set; } = new List<Company>();
    	
    	public void UpdatePrice(string name, double price) {
    		var index = Companies.FindIndex(x => x.Name == name);
    		if(index >= 0)
    		{
    			var previous = Companies[index];
    			Companies[index] = new Company(previous.Name, previous.Symbol, price, price - previous.Price);
    		}
    	}
    }
    
    class Company
    {
    	public Company(string name, string symbol, double price, double change) {
    		Name = name;
    		Symbol = symbol;
    		Price = price;
    		Change = change;
    	}
    	public string Name { get; }
    	public string Symbol { get; }
    	public double Price { get; }
    	public double Change { get; }
    	///...
    }
