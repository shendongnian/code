    [Route("[controller]")]
    public class WorkerInfoController : Controller {
    
        //...
    
        //PUT workerinfo/123456
        [HttpPut("{activeContractId}")]
        public async Task<IActionResult> Put([FromRoute] string activeContractId, [FromBody] WorkerRead worker) {
            var companyId = GetCompanyId();
            var period = GetPeriod();
            var language = GetLanguage();
            var workerInfo = await _workerInfoService.UpdateWorkerIdentity(companyId, activeContractId, language, worker);
    
            return Ok(workerInfo);
        }    
    }
