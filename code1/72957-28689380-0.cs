    //first: Create a class as your view model
    public class EventViewModel {
    public int Id{get;set}
    public string Property1{get;set;}
    public string Property2{get;set;}
    }
    //then from your method
    [HttpGet]
    public async Task<ActionResult> GetEvent(){
    var events = await db.Event;
    List<EventViewModel> model = events.Select(event => new EventViewModel(){
    Id = event.Id,
    Property1 = event.Property1,
    Property1 = event.Property2
    }).ToList();
    return Json(new{ data = model }, JsonRequestBehavior.AllowGet);
    }
