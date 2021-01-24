    public class Utf8ForExcelCsvResult : IActionResult
    {
        public string Content{get;set;}
        public string ContentType{get;set;}
        public string FileName {get;set;}
        public Task ExecuteResultAsync(ActionContext context)
        {
            var Response =context.HttpContext.Response;
            Response.Headers["Content-Type"] = this.ContentType;
            Response.Headers["Content-Disposition"]=$"attachment; filename={this.FileName}; filename*=UTF-8''{this.FileName}";
            using(var sw = new StreamWriter(Response.Body,System.Text.Encoding.UTF8)){
                sw.Write(Content);
            }
            return Task.CompletedTask ;
        }
    }
