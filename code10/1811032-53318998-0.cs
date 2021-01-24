    public sealed class CaseController : ApiControllerBase {
        private readonly ICaseProcess caseProcess;
     
        public CaseController(ICaseProcess caseProcess) {
            this.caseProcess = caseProcess;
        }
    
        [HttpGet]
        [Route("{id:int}")]
        public ICaseDto<object> Get(int id) {
            return caseProcess.GetCase(id);
        }
    }
