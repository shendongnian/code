    public class IgnoreNullValuesFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType;
                var value = JsonConvert.SerializeObject(objectContent.Value, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                objectContent.Value = value;
                //If you want to send your response as strongly type
                JObject jObject = JObject.Parse(value);
                objectContent.Value = jObject;
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
