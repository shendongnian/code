    [RoutePrefix("api/Test")]
    public class TestController : ApiController {
        private myEntity db = new myEntity();
        //GET api/Test
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll() {
            // Get a list of customers
            var customers = db.Customers.ToList();    
            // Write the list of customers to the response body
            return OK(customers);
        }
    
        //GET api/Test/1
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id) {
            // Get Customer by id
            Customer customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            if (customer == null) {
                return NotFound();
            }
            return Ok(customer);
        }
    }
