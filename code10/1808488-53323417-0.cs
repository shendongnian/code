    public partial class ApproveController : Controller
    {
        const string IDX_ACTIONRESULT = @"ActionResult";
        public ActionResult MyAction(FormCollection collection)
         {
             try
             {
                 //Do stuff
                 TempData[IDX_ACTIONRESULT] = @"Action completed successfully";
                 return RedirectToAction("MainWindow");
             }
             catch (Exception e)
             {
                 Logger.reportException(e);
                 TempData[IDX_ACTIONRESULT] = @"The Action failed. Please contact your system administrator for assistance";
             }
         }
    }
