    public class ExampleActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            // Find a single argument we can treat as IJsonPatchDocument.
            var jsonPatchDocumentActionArgument = ctx.ActionArguments.SingleOrDefault(
                x => typeof(IJsonPatchDocument).IsAssignableFrom(x.Value.GetType()));
            // Here, jsonPatchDocumentActionArgument.Value will be null if none was found.
            var jsonPatchDocument = jsonPatchDocumentActionArgument.Value as IJsonPatchDocument;
            if (jsonPatchDocument != null)
            {            
                jsonPatchDocument.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
            }
        }
    }
