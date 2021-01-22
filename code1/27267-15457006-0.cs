    [CreateRepositoryByUser]
    public class MFCController : Controller
    {
        protected MFCRepository _repository
        {
            get { return ViewData["repository"] as MFCRepository; }
        }
    ...
