    [Route("api/Client")]
    public class ClientController : Controller
    {
        public IActionResult Client(string name, DateTime date, int id)
        {
            string return1 = "return1", return2 = "return2";
    
            return Ok(new { return1, return2});
        }
    }
