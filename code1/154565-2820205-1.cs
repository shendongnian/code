    public class CensusHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string fileName = String.Format(
                CultureInfo.CurrentUICulture,
                "E_{0:00}{1:00}.csv",
                DateTime.Today.Month,
                DateTime.Today.Day
                );
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader(
                "Content-Disposition", String.Format(null, "attachment; filename={0}", fileName)
                );
            //Dump the CSV content to context.Response
            context.Response.Flush();
        }
        public bool IsReusable { get { return false; } }
    }
