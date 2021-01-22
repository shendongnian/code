    [HandleError]
    public abstract class MyControllerBase : Controller
    {
        ...
    }
    [Authorize(Roles="Admin")]
    public abstract class AdminControllerBase : MyControllerBase
    {
        ....
    }
