        public class CustomJsonInputFormatter : JsonInputFormatter
        {
        public CustomJsonInputFormatter(
                ILogger logger,
                JsonSerializerSettings serializerSettings,
                ArrayPool<char> charPool,
                ObjectPoolProvider objectPoolProvider,
                MvcOptions options,
                MvcJsonOptions jsonOptions) : base(logger, serializerSettings, charPool, objectPoolProvider, options, jsonOptions)
        {
        }
    
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            InputFormatterResult result = await base.ReadRequestBodyAsync(context, encoding);
            var pagedList = (IPagedRequest<object>)result.Model;
            if (pagedList != null)
            {
                if (pagedList.Page == 0) pagedList.Page = 1;
                if (pagedList.PageSize == 0) pagedList.PageSize = 25;
            }
            return result;
        }
    
        }
