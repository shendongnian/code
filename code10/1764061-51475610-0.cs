    [Route("api/Update")]
    public class UpdateController
    {
       [Route("PersonalInfo")]
       [HttpPost] 
       public HttpResponseMessage UpdateUser(PersonalInfoModel 
       personalInfo){}
    
       [Route("Roles")]
       [HttpPost] 
       public HttpResponseMessage UpdateUser(RolesModel roles){}
    }
