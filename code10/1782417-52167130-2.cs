    public class ContactController : Controller {
        private readonly IEmail email;
    
        public ContactController(IEmail email) {
            this.email = email;
        }
    
        public IActionResult Contact() {
            return View(new Contato());
        }
    
        [HttpPost]
        public async Task<IActionResult> ContactAsync(Contato contato) {        
            await email.SendAsync(contato);
            return Ok();
        }
    }
