    public class CustomerController : Controller
    {
            [SubmitButtonSelector(Name="Save")]
            public ActionResult Save()
            {
                return Content("Save Called");
            }
            [SubmitButtonSelector(Name = "Delete")]
            public ActionResult Delete()
            {
                return Content("Delete Called");
            }
    }
