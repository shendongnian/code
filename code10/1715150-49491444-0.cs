    public class ClassController : BaseController
    { 
        ...
        [Authorize(Roles = ("Administrator, Management, Student"))]
        public ActionResult Method()
        {
            ...
