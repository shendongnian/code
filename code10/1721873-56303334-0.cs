    public class DocumentsController : ApiController
    {
            public HttpResponseMessage Pdf()
            {
                PDFController controller = new PDFController();
                RouteData route = new RouteData();
                route.Values.Add("action", "getPdf"); // ActionName
                route.Values.Add("controller", "PDF"); // Controller Name
                System.Web.Mvc.ControllerContext newContext = new 
                System.Web.Mvc.ControllerContext(new HttpContextWrapper(System.Web.HttpContext.Current), route, controller);
                controller.ControllerContext = newContext;
                var actionPDF = controller.getPdf(); 
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(actionPDF);// new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = "SamplePDF.PDF";
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                return response;
            }            
    }
