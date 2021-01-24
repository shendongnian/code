    public class ContactController : Controller
    {
        public ContactController(Email email)
        {
            Email = email;
        }
    
        public Email Email { get; }
    
        public IActionResult Contact()
        {
            return View(new Contato());
        }
    
        [HttpPost]
        public async Task<IActionResult> ContactAsync(Contato contato)
        {
            Email.SendAsync(contato);
    
            return Ok();
        }
    }
