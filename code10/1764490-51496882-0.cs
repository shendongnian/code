    public class DBFrameworkController: ApiController {
        private readonly IDBFrameworkBL objDBFrameworkBL;
    
        public DBFrameworkController(IDBFrameworkBL objDBFrameworkBL) {
            this.objDBFrameworkBL = objDBFrameworkBL;
        }
    
        [HttpPost]
        [Route("DeleteEnumeration")]
        public int DeleteEnumeration(TemplateDto template) {
            try {
                return objDBFrameworkBL.DeleteEnumeration(template);
            } catch (Exception ex) {
                LogUtilities.LogException(ex);
                return 0;
            }    
        }
    }
