    public class JsonResultAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
    
            // Detect that the result is of type JsonResult
            if (filterContext.Result is JsonResult)
            {
                var jsonResult = filterContext.Result as JsonResult;
    
                // Dig into the Data Property
                foreach(var prop in jsonResult.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    var propName = prop.Name;
                    var propValue = prop.GetValue(jsonResult.Value,null);
    
                    Console.WriteLine("Property: {0}, Value: {1}",propName,     propValue);
    
                    // Detect if property is an DateTime
                    if (propValue is DateTime)
                    {
                        // Take some action
                    }
                }
            }
        }
    }
