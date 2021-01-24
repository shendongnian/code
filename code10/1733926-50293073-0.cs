    public class UpdateFileDownloadOperations : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry s, ApiDescription a)
        {
            if (operation.operationId == "DownloadFile_Get")
            {
                operation.produces = new[] { "application/octet-stream" };
            }
        }
    }
