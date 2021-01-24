    [Route("api/remote/[action]")] //<-- NOTE Token replacement in route templates
    [ApiController]
    public class RemoteController : ControllerBase {
        private readonly MyContext _context;
    
        public RemoteController(MyContext context) { 
            _context = context; 
        }
        //GET api/remote/NewAc
        [HttpGet]
        public async Task<IActionResult> NewAc() {
            var r = await _context.TypeOfAccounts.AnyAsync();
            return Ok(new { r = true });
        }
        //GET api/remote/NewAc/test1
        [HttpGet("{accountType}")]
        public async Task<IActionResult> NewAc(string accountType) {
            var r = await _context.TypeOfAccounts.AnyAsync(o => o.AccountType.ToUpper() == AccountType.ToUpper());
            return Ok(new { r = !r });
        }
    }
