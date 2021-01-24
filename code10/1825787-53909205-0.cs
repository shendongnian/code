    public class PersonController : Controller
    {
        private readonly IPersonService personService;
        public PersonController()
        {
            presonService =  new PersonService();
        }
        public async Task<JArray> Get(int? id)
        {
            var model = await personService.GetInfo(id, ConnHelper.ConnectionString());
            JArray a = (JArray)JToken.FromObject(model);
            return Json(a);
            //return model;
        }
 
    public async Task<List<Person>> GetObject(int? id)
                {
                    var model = await personService.GetInfo(id, ConnHelper.ConnectionString());                
                    return Json(model);
                }
            }
