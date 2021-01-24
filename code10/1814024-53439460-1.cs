    [Route("api/[controller]")]
    public class CustomersController: Controller {
    
        //...
        [HttpGet("GetAll")]
        [AcceptVerbs("Get", "Post")]
        public IActionResult SelectCAllCustomers() {
            var model = customerDetailsRepository.FindAll("SelectAllCustomers").ToList();
            return Ok(model);            
        }
    }
