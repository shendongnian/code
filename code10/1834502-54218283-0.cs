    void Main()
    {
    	var list = new List<string>
    	{
    		"This is a nothing line",
    		"No001 FOO67 368.80",
    		"No001 FOO67 17.68",
    		"SHORT 12345"
    	};
    	
    	
    	var invoices = list
    		.Select((l, i) => new InvoiceData
    		{ 
    			Line = l, 
    			NextLine = i < list.Count - 1 ? list[i + 1] : string.Empty 
    		})
    		.Where(x => x.Line.StartsWith("No"))
    		.ToList();
    }
    
    public class InvoiceData
    {
    	public string Line { get; set; }
    	public string NextLine { get; set; }
    	public bool IsAdjustment => NextLine.StartsWith("SHORT");
    	public decimal Amount =>
    		IsAdjustment 
    			? -decimal.Parse(Line.Split(' ')[2])
    			: decimal.Parse(Line.Split(' ')[2]);
    	public string Reference =>
    		IsAdjustment
    			? NextLine.Split(' ')[1]
    			: Line.Split(' ')[1];
    }
