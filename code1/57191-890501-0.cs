using System;
using System.Web;
using System.Web.Services;
namespace WebServiceIntrinsicObjects
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            // HERE'S THE LINE:  just get the request object from HTTPContext.Current (a static that returns the current HTTP context)
            string test = string.Join(",", HttpContext.Current.Request.Headers.AllKeys);
            return test;
        }
    }
}
