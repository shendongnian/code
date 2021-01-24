    public class DocXResult : IActionResult
    {
        private DocX _doc;
        public DocXResult(DocX doc) { _doc = doc); }
        public Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/octet-stream";
            _doc.SaveAs(response.Body);
            
            return Task.CompletedTask;
        }
    }
    public IActionResult SendDocX()
    {
        DocX doc = null; // do your stuff
        this.Response.RegisterForDispose(doc);
        return new DocXResult(docX);
    }
