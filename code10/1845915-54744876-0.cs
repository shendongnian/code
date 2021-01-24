    public class ReportApiController : ApiController, IReportController 
    { 
        public object PostReportAction(Dictionary<string, object> jsonResult) 
        { 
            return ReportHelper.ProcessReport(jsonResult, this); 
        } 
 
        [System.Web.Http.ActionName("GetResource")] 
        [AcceptVerbs("GET")] 
        public object GetResource(string key, string resourcetype, bool isPrint) 
        { 
            return ReportHelper.GetResource(key, resourcetype, isPrint); 
        } 
 
        public void OnInitReportOptions(ReportViewerOptions reportOption) 
        { 
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/App_Data/GroupingAgg.rdl"), FileMode.Open, FileAccess.Read); 
            reportOption.ReportModel.Stream = fs; 
        } 
 
        public void OnReportLoaded(ReportViewerOptions reportOption) 
        { 
             
        } 
    } 
 
