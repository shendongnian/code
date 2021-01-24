    [RoutePrefix("api/ProductionOrder")]
    public class ProductionOrder : ApiController
    {
    	[HttpPut]
    	[Route("RequestCodeForIncompleteOrder/{productionOrderId}")]
    	public ActionResult RequestCodeForIncompleteOrder(int productionOrderId){}
    }
