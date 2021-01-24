    [Route("api/[controller]")]
    public class CustomersController: Controller {
    
        //...
        [HttpGet("GetAll")]
        [AcceptVerbs("Get", "Post")]
        public IActionResult SelectCAllCustomers() {
            try {
                var model = customerDetailsRepository.FindAll("SelectAllCustomers").ToList();
                return Ok(model);
            } catch (Exception ex) {
                return InternalServerError(ex);
            }
        }
    }
