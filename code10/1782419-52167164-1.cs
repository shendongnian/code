    public class ContactController : Controller
    {
        private readonly EMail email;
        public ContactController(Email email)
        {
            this.email = email;
        }
        public IActionResult Contact()
        {
            return View(new Contato());
        }
    
        [HttpPost]
        public async Task<IActionResult> ContactAsync(Contato contato)
        {
            email.SendAsync(contato);
    
            return Ok();
        }
    }
