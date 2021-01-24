    public class RoomHk
    {
    	public int RoomHkId { get; set; }
    	public int RoomId { get; set; }
    	public DateTime? DeepCleaning { get; set; }
    	public DateTime? NewLinen { get; set; }
    }
    
    [HttpGet]
    public ActionResult SetCleaningStatus() 
    {
    	var model = new RoomHk();
    	
    	return View(model);
    }
    
    [HttpPost]
    public ActionResult SetCleaningStatus(RoomHk arg) 
    {
    	bool response = new {
    		success = true
    	};
    	
    	// Here is your RoomId
    	arg.RoomId;
    	
    	arg.NewLinen = DateTime.Now;
    	
    	// Save posted data to DB
    	// ...
    	
    	// Return your response here
    	return Json(response);
    }
