    public class CustomerListResponse {
        public List<YourCustomerClassName> Customers {get;set;}
    }
    
    public ActionResult<CustomerListResponse> GetStatus(GetStatusRequest request)
    {
        // check request
        if(doyourcheckhere == false) {
            return BadRequest();
        }
    
        // load your data here. Do not think in JArray and JObject
        // simply use POCOs
        var customers = GetCustomers(request.CustomerId);
    
        // if you need to reformat, create separate class and use e.g. automapper
    
        return new CustomerListResponse {
            Customers = customers
        };
    }
