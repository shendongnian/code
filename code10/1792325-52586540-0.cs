     using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        
        namespace MvcApplication1.Controllers
        {
            public class SubmitController : System.Web.Mvc.Controller
            {
                [HttpPost]
                public PartialViewResult Process(string myArray)
                {
                  String[] Items = myArray.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);
                  //print
                   Items.ToList().ForEach(i => System.Diagnostics.Debug.WriteLine(i.ToString()));
        
                    return null;
                }
            }
        }
