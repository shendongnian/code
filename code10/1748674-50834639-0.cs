    public class dataJson1
    {
    	public List<Detail> data { get; set; }
    }
        
    public class dataJson2
    {
    	public Dictionary<string, Detail> data { get; set; }
    }
    
    public class Detail
    {
    	public DateTime EffectiveDate { get; set; }
    	public int IncludedQuantity { get; set; }
    	public string Category { get; set; }
    	//add the rest of the props here
    }
