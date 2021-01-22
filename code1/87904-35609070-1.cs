    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Mail;
    using System.Web;
    using System.Web.Mvc;
    
    namespace YOURNAMESPACEHERE
    {
        public class ValidationController : Controller
        {
            [HttpPost]
            public JsonResult IsValidDateOfBirth(string dob)
            {
                var min = DateTime.Now.AddYears(-21);
                var max = DateTime.Now.AddYears(-110);
                var msg = string.Format("Please enter a value between {0:MM/dd/yyyy} and {1:MM/dd/yyyy}", max,min );
                try
                {
                    var date = DateTime.Parse(dob);
                    if(date > min || date < max)
                        return Json(msg);
                    else
                        return Json(true);
                }
                catch (Exception)
                {
                    return Json(msg);
                }
            }
        }
    }
