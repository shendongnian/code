    protected override bool CheckAccessCore(OperationContext operationContext)
            {
                string actionName = GetActionName(operationContext);
                /* do what all further authorization check you want to do
                 * like "can user access method with actionname="Create"*/
            }
    
            private static string GetActionName(OperationContext operationContext)
            {
                string action;
    
                if (operationContext.RequestContext != null)
                {
                    action = operationContext.RequestContext.RequestMessage.Headers.Action;
                }
                else
                {
                    action = operationContext.IncomingMessageHeaders.Action;
                }
    
                if (action == null)// REST Service - webHttpBinding
                {
                    action = WebOperationContext.Current.IncomingRequest.UriTemplateMatch == null || WebOperationContext.Current.IncomingRequest.UriTemplateMatch.Data == null
                             ? String.Empty : WebOperationContext.Current.IncomingRequest.UriTemplateMatch.Data.ToString();
                }
                else
                {
                    action = action.Split('/').Last();
                }
                return action;
            }
