    [System.Web.Http.HttpGet]
    public HttpResponseMessage GetAllOrders()
    {
        //var serviceResult = orderService.LoadOrders();
        // var isValid = serviceResult.IsValid
        var isValid = true;
        if (isValid)
        {
            // I used hardcoded values here just to show how to return a proper result
            // you can call your service instead and do the mapping/other stuff
    
            var result = new List<OrderDto>()
            {
                new OrderDto(){
                    OrderID = 3,
                    Article = "blah1"
                },
                new OrderDto(){
                    OrderID = 4,
                    Article = "blah2"
                }
            };
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        else
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Message");
    
        }
    }
    public class OrderDto
    {
        public int OrderID { get; set; }
    
        public string Article { get; set; }
    }
