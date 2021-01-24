    public class ImportFormsController : Controller
        {
            public JsonResult INTImportData(int jobId)
            {
                //if (Session["UserLogon"] != null)
                //{
                BLINTForms objForm = new BLINTForms();
                var objDCFormList = new DCForm.DCFormList();
                //int jobId = Session["Job_ID"] == null ? 0 : (int)Session["Job_ID"];
                //ViewBag.jobId = jobId;
    
                objDCFormList.Form = objForm.GetINTFormTempDataByJobId(jobId);
                //TempData["DCFormList"] = objDCFormList.Form;
                //Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(objDCFormList.Form, JsonRequestBehavior.AllowGet);
                //}
                //else
                //return Json("Login required", JsonRequestBehavior.AllowGet);
    
            }
    
        }
    
        public class BLINTForms
        {
            public List<DCForm> GetINTFormTempDataByJobId(int jobId)
            {
    
                List<DCForm> objDCFormList = new List<DCForm>();
                DCForm objDCForm;
                int record = 0;
                try
                {
                    for (var i = 0; i < 5; i++)
                    {
                        objDCForm = new DCForm();
                        objDCForm.SerialNo = ++record;
                        objDCForm.PayerId = 100;
                        objDCFormList.Add(objDCForm);
                    }
    
    
                    return objDCFormList;
                }
                catch (Exception exce)
                {
                    throw exce;
                }
                finally
                {
    
                }
            }
        }
    
        public class DCForm : DataOperationResponse
        {
            public int SerialNo { get; set; }
            public int PayerId { get; set; }
    
    
            public class DCFormList : DataOperationResponse
            {
                private List<DCForm> _form = null;
    
                public DCFormList()
                {
                    if (_form == null)
                        _form = new List<DCForm>();
                }
    
                public List<DCForm> Form
                {
                    get { return _form; }
                    set { _form = value; }
                }
            }
        }
    
        public class DataOperationResponse
        {
            //public string Message { get; set; }
        }
