    [TestClass]
    public class BadExample
    {
    	public class Item
    	{
    		public String Value { get; set; }
    	}
    	public IEnumerable<Item> SomebodysElseMethodWeHaveNoControlOver()
    	{
    		var values = "at the end everything must be in upper".Split(' ');
    		return values.Select(x => new Item { Value = x });
    	}
    	[TestMethod]
    	public void Test()
    	{
    		var items = this.SomebodysElseMethodWeHaveNoControlOver();
    		foreach (var item in items)
    		{
    			item.Value = item.Value.ToUpper();
    		}
    		var mustBeInUpper = String.Join(" ", items.Select(x => x.Value).ToArray());
    		Trace.WriteLine(mustBeInUpper); // output is in lower: at the end everything must be in upper
    		Assert.AreEqual("AT THE END EVERYTHING MUST BE IN UPPER", mustBeInUpper); // <== fails here
    	}
    }
