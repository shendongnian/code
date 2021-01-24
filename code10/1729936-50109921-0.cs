    public class HomeController : ApiController
    {
    	[HttpPost]
    	[Route("api/CustomerProfile/Save")]
    	public IHttpActionResult SaveCustomerProfile([FromBody] Customer _input)
    	{
    		masterEntities masterEntities = new masterEntities();
    		var cust = masterEntities.Customers.AsNoTracking().Where(w => w.ID == _input.ID).FirstOrDefault();
    
    		if (cust == null)
    		{
    			_input.ID = Guid.NewGuid();
    			_input.Alias = 0;
    			_input.CreatedOn = DateTime.Now;
    
    			masterEntities.Customers.Add(_input);
    		}
    		else
    		{
    			masterEntities.Customers.Attach(_input);
    			masterEntities.Entry(_input).State = System.Data.Entity.EntityState.Modified;
    		}
    
    		masterEntities.SaveChanges();
    
    		return Ok();
    	}
    }
