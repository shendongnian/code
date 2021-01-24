    public class UserValuesController : Controller
    {
        private readonly DAL _dal;
        public UserValuesController(DAL dal)
        {
            _dal = dal;
        }
    
        [HttpGet("[action]")]
        public List<Uservaluesfull> Get()
        {            
            var SID = User.FindFirst("onprem_sid")?.Value;
            return new _dal.GetUservalues(SID);
        }
    }
