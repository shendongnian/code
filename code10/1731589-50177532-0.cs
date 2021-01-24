    [RoutePrefix("widgets/download-functions")]
    public class WidgetDownloadController : Controller
...
    
    [Route("download/{publishedReportId}"), HttpGet]
    public ActionResult Download(int publishedReportId)
