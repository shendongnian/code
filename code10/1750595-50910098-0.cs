    public class CustomerController : BaseController
    {
    
        public IHttpActionResult Get()
        {
    
            var customers = new List<object>();
            return CreateResponse<List<object>>(HttpStatusCode.Created, customers);
        }
    
        public IHttpActionResult Post([FromBody]Customer customer)
        {
            int custId = 17;
            return CreateResponse<int>(HttpStatusCode.Created, custId);
        }
    }
    
    public abstract class BaseController : ApiController
    {
    
        protected IHttpActionResult CreateResponse<TData>(HttpStatusCode httpStatus, TData data)
        {
            // Problem here is that BaseController is not a generic class anymore, so you can't store your responses but then again, why would you want to store them in a variable?
            var reponse = new APIResponseTO<TData>()
            {
                HttpStatus = httpStatus,
                Data = data
            };
    
            return Ok(reponse);
        }
    }
