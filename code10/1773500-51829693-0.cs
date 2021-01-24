    public class SnakeCaseActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            var requestUri = controllerContext.Request.RequestUri;
            var queryPairs = controllerContext.Request.GetQueryNameValuePairs().ToList();
            if (!queryPairs.Any())
            {
                return base.SelectAction(controllerContext);
            }
            queryPairs = queryPairs.Select(x =>
                    new KeyValuePair<string, string>(CamelCaseToSnakeCaseConverter.FromSnakeCase(x.Key), x.Value))
                .ToList();
            var newQueryParams = queryPairs.Select(x => $"{x.Key}={x.Value}").Aggregate((x, y) => x + "&" + y);
            var builder = new UriBuilder(requestUri)
            {
                Query = newQueryParams
            };
            controllerContext.Request.RequestUri = builder.Uri;
            return base.SelectAction(controllerContext);
        }
    }
