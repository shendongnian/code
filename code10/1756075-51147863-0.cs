    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "does/work")]
        public bool DoesWork(WorkDetails workDetails) {
            bool Success = false;
            var work = worDetails.something; //if the type matches with your json content, you should have the values populated under work details
            IncomingWebRequestContext woc = WebOperationContext.Current.IncomingRequest;
            return Success;
        }
