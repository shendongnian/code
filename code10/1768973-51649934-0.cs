    void Main()
    {
    	List<FarmDiary> farmDiary = new List<FarmDiary> {
    		new FarmDiary{Id=1, PersonInCharge="Bob",Date=new DateTime(2018,6,1)},
    		new FarmDiary{Id=2, PersonInCharge="John",Date=new DateTime(2018,6,2)},
    		new FarmDiary{Id=3, PersonInCharge="Bob",Date=new DateTime(2018,6,15)},
    		new FarmDiary{Id=4, PersonInCharge="David",Date=new DateTime(2018,7,1)},
    		new FarmDiary{Id=5, PersonInCharge="Zachary",Date=new DateTime(2018,6,10)},
    	};
    	
    	List<string> staffNames = farmDiary
    	.GroupBy(d => d.PersonInCharge)
    	.OrderByDescending(x => x.OrderByDescending(d => d.Date).First().Date)
    	.Select(x => x.Key)
    	.ToList();
    	
    	staffNames.Dump();
    }
    
    public class FarmDiary
    { 
    	public int Id { get; set; }
    	public string PersonInCharge { get; set; }
    	public DateTime Date { get; set; }
    }
