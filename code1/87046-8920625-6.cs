    public class NullableWebHttpBehavior : WebHttpBehavior
    {
        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new NullableQueryStringConverter();
        }
    }
