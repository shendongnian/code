    public class SwaggerFilChunkUploadOperationProcessor : IOperationProcessor
    {
        public Task<bool> ProcessAsync(OperationProcessorContext context)
        {
            var data = context.OperationDescription.Operation.Parameters;
            
            //File upload
            data.Add(new SwaggerParameter()
            {
                IsRequired = true,
                Name =  "file",
                Description = "filechunk",
                Type = JsonObjectType.File,
                Kind = SwaggerParameterKind.FormData
            });
            
            //custom formdata (not needed for the file upload)
            data.Add(new SwaggerParameter()
            {
                IsRequired = true,
                Name = "file-name",
                Description = "the original file name",
                Type = JsonObjectType.String,
                Kind = SwaggerParameterKind.FormData
            });
            return Task.FromResult(true);
    }
    //defined as Attribute Usage, so you can use the attribute in your Controller
    public class SwaggerFileChunkUploadAttribute : SwaggerOperationProcessorAttribute
    {
        public SwaggerFileChunkUploadAttribute() : base(typeof(SwaggerFilChunkUploadOperationProcessor))
        {
        }
    }
