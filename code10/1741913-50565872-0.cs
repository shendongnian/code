    using System.Linq; 
    using System.Web.Mvc; 
    using KMS.Models; 
    using WebMatrix.Data; 
    using System.IO;
    
    
    namespace KMS.Controllers
     {
    
    public class KMSController : Controller{
        public ActionResult Index()
        {
            //Insert the actual entity referred to your db variable. 
            //Probably something like:
            //var db = Some Database Context
    
            KMSConection cs = new KMSConection();
            cs.Areas = (from o in db.Areas select o).Tolist();
            cs.AreaTypes = (from o in db.AreaTypes select or).Tolist();
            return View(cs);
        }
      }
    }
