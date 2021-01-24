    public class SomeController : Controller
    {
        private readonly RepositoryContext _repo;
        public SomeController(SomeRepository someRepo)
        {
            _repo = someRepo;
        }
        [HttpPost]
        public IActionResult CreateOrUpdate([FromBody] SomeType type)
        {
            try
            {
                // using CreateOrUpdate method makes it necessary to check for existance
                SomeType checkIfExists = _repo.GetById(type.id);
                
                if(checkIfExists != null)
                {
                    // Do some stuff with object
                    // ...
                    _repo.CreateOrupdate(checkIfExists);
                }
                else 
                {
                    checkIfExists = new SomeType();
                    // Do some stuff
                    _repo.CreateOrupdate(checkIfExists);
                }
                _repo.SaveChanges();
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
