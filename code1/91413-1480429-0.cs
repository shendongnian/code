    public class JsonFilter : ActionFilterAttribute
        {
            public string Parameter { get; set; }
            public Type JsonDataType { get; set; }
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.ContentType.Contains("application/json"))
                {
                    string inputContent;
                    using (var sr = new StreamReader(filterContext.HttpContext.Request.InputStream))
                    {
                        inputContent = sr.ReadToEnd();
                    }
    
                    var result = JsonConvert.DeserializeObject(inputContent, JsonDataType);
                    filterContext.ActionParameters[Parameter] = result;
                }
            }
        }
    [AcceptVerbs(HttpVerbs.Post)]
    [JsonFilter(Parameter="user", JsonDataType=typeof(User))]
    public ActionResult Submit(User user)
    {
        // user object is deserialized properly prior to execution of Submit() function
    
        return View();
    }
