    [RoutePrefix("api/SyncPersonnelViaAwsApi")]
    public class SyncPersonnelViaAwsApiController : ApiController {
        //GET api/SyncPersonnelViaAwsApi/4
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id) {
            return Ok("value");
        }
        //POST api/SyncPersonnelViaAwsApi
        [HttpPost]
        [Route("")]
        public IHttpActionResult SapCall([FromBody]string xmlFile) {
            string responseMsg = "Failed Import User";
            if (!IsNewestVersionOfXMLFile(xmlFile)) {
                responseMsg = "Not latest version of file, update not performed";
            } else {
                Business.PersonnelReplicate personnelReplicate = BusinessLogic.SynchronisePersonnel.BuildFromDataContractXml<Business.PersonnelReplicate>(xmlFile);
                bool result = Service.Personnel.SynchroniseCache(personnelReplicate);
                if (result) {
                    responseMsg = "Success Import Sap Cache User";
                }
            }
            var data = new { 
                response = responseMsg,
                isNewActiveDirectoryUser = false
            };
            
            Ok(data);
        }
    }
    
