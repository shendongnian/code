    public class BalanceItem
    {
    	public string asset { get; set; }
    	public double free { get; set; }
    	public double locked { get; set; }
    }
    
    
    public class Items
    {
    	public List<BalanceItem> balances { get; set; }
    }
	var items = JsonConvert.DeserializeObject<Items>(MyData);
	var btc = items.balances.FirstOrDefault (b => b.asset == "BTC");
	if (btc != null)
	{
		Console.WriteLine(btc.free);
	}
