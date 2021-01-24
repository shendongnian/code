    void Main()
    {
    	List<Data_Raw> myRawData = new List<Data_Raw> {
    	   new Data_Raw(new DateTime(2018,1,1), 2, 1),
    	   new Data_Raw(new DateTime(2018,1,2), 3, 1),
    	   new Data_Raw(new DateTime(2018,1,3), 4, 1),
    	   new Data_Raw(new DateTime(2018,1,4), 5, 1),
    	   new Data_Raw(new DateTime(2018,1,5), 6, 1),
    	   new Data_Raw(new DateTime(2018,1,6), 7, 1),
    	   new Data_Raw(new DateTime(2018,1,7), 8, 1),
    	};
    
    	var groupSize = 3;
    	var result = from i in Enumerable.Range(0, myRawData.Count() - (groupSize - 1))
    				 let myGroup = myRawData.Skip(i).Take(groupSize)
    				 select new
    				 {
    					 Values = string.Join(",", myGroup.Select(rd => rd.PriceRaw.ToString())),
    					 Average = myGroup.Average(rd => rd.PriceRaw)
    				 };
    }
    
    public class Data_Raw
    {
    	public DateTime DateDataRaw { set; get; }
    	public double PriceRaw { set; get; }
    	public double PercentageReturnsRaw { set; get; }
    
    	public Data_Raw(DateTime _dateDataRaw, double _priceRaw, double _percentageReturnsRaw)
    	{
    		DateDataRaw = _dateDataRaw;                     //1
    		PriceRaw = _priceRaw;
    		PercentageReturnsRaw = _percentageReturnsRaw;
    	}
    }
