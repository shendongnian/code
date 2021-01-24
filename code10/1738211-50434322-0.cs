    using System.Web.Http;
    using System.Web.Http.Cors;
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EvalSamplesController : ApiController
    {
        [HttpGet]
        public List<EvalSamplesViewModel> GetHeaderList()
        {
            List<EvalSamplesViewModel> simpleModel = obj.ReadAllList();
            return simpleModel;
        }
    }
