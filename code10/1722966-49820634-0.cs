    void Main()
    {
    	var FlowerDates = new List<Flower>();
    	FlowerDates.Add(new Flower {FlowerId =1});//Comment this out and you will get NULL
    	FlowerDates.Add(new Flower {FlowerId =2});
    	
    	//I simplified the condition to focus on choosing a null value
    	//If Any() evaluates to true then get current time, else return null
        //Yes you are doing a projection here, but setting a variable is effectively the same thing and simpler to follow
    	var ClosedDate = FlowerDates.Where(c => c.FlowerId == 1)
    		.Any()
    		   ? DateTime.Now
    		   : (DateTime?)null;
    			   
    	//ClosedDate is either NULL or DateTime.Now depending on Any()
    }
    
    public class Flower
    {
    	public int FlowerId { get; set; }
    }
