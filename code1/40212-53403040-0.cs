    public class MyController : Controller
    {
      private string folderPath;
      public MyController()
      {       
        // Throws an error because Server is null
        folderPath = Server.MapPath("~/uploads"); 
        // Throws an error because this.ControllerContext is null
        folderPath = this.ControllerContext.HttpContext.Server.MapPath("~/uploads"); 
      }
    }
