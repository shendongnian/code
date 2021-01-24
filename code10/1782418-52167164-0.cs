    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View(new Contato());
        }
    
        [HttpPost]
        public async Task<IActionResult> ContactAsync(Contato contato, [FromServices]Email email)
        {
            email.SendAsync(contato);
    
            return Ok();
        }
    }
