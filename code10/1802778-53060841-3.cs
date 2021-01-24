    private static void SetContentType()
    {
        if (WebOperationContext.Current != null)
        {
            var response = WebOperationContext.Current.OutgoingResponse;
            response.ContentType = "text/plain";
        }
    }
