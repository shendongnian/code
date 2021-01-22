    public class MyService: IMyService //IMyService defines the contract
    {
        [WebGet(UriTemplate = "resource/{externalResourceId}")]
        public Resource GetResource(string externalResourceId)
        {
            int resourceId = 0;
            if (!Int32.TryParse(externalResourceId, out resourceId) || externalResourceId == 0) // No ID or 0 provided
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            var resource = GetResource(resourceId);
            return resource;
        }
    }
