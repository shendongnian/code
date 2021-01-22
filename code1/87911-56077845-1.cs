    namespace Controllers
    {
        public class ValidationController : Controller
        {
            [HttpGet]
            [ActionName("ValidateDateBetweenYearsFromNow")]
            public JsonResult ValidateDateBetweenYearsFromNow_Get()
            {
                //This method expects 3 parameters, they're anonymously declared through the Request Querystring,
                //Ensure the order of params is:
                //[0] DateTime
                //[1] Int Minmum Years Ago e.g. for 18 years from today this would be 18
                //[2] int Maximum Years Ago e.g. for 100 years from today this would be 100
                var msg = string.Format("An error occured checking the Date field validity");
                try
                {
                    int MinYears = int.Parse(Request.QueryString[1]);
                    int MaxYears = int.Parse(Request.QueryString[2]);
    
                    //Use (0 - x) to invert the positive int to a negative.
                    var min = DateTime.Now.AddYears((0-MinYears));
                    var max = DateTime.Now.AddYears((0-MaxYears));
                    
                    //reset the response error msg now all parsing and assignmenst succeeded.
                    msg = string.Format("Please enter a value between {0:dd/MM/yyyy} and {1:dd/MM/yyyy}", max, min);
                    var date = DateTime.Parse(Request.QueryString[0]);
                    if (date > min || date < max)
                        //switch the return value here from "msg" to "false" as a bool to use the MODEL error message
                        return Json(msg, JsonRequestBehavior.AllowGet);
                    else
                        return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
