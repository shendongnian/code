    public class FileUploadOperation : IOperationFilter
    {
        private readonly IEnumerable<string> _actionsWithUpload = new []
        {
            //add your upload actions here!
            NamingHelpers.GetOperationId<FilesController>(nameof(FilesController.Post))
        };
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (_actionsWithUpload.Contains(operation.OperationId) )
            {
                operation.Parameters.Clear();
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "file",
                    In = "formData",
                    Description = "Upload File",
                    Required = true,
                    Type = "file"
                });
                operation.Consumes.Add("multipart/form-data");
            }
        }
    }
    
        /// <summary>
        /// Refatoring friendly helper to get names of controllers and operation ids
        /// </summary>
        public class NamingHelpers
        {
            public static string GetOperationId<T>(string actionName) where T : Controller => $"{GetControllerName<T>()}{actionName}";
    
            public static string GetControllerName<T>() where T : Controller => typeof(T).Name.Replace(nameof(Controller), string.Empty);
        }
