    public class QueryParameterActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            var mapping = GetActionMapping(controllerContext.ControllerDescriptor);
    
            var parameters = controllerContext.Request.GetQueryNameValuePairs();
            foreach (var parameter in parameters)
            {
                if (parameter.Key == "action")
                {
                    if (mapping.Contains(parameter.Value))
                    {
                        // Provided that all of your actions have unique names.
                        // Otherwise mapping[parameter.Value] will return multiple actions and you will have to match by the method parameters.
                        return mapping[parameter.Value].First();
                    }
                }
            }
    
            return null;
        }
    }
