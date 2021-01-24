    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SwaggerControllerNameAttribute : Attribute
    {
        public string ControllerName { get; private set; }
        public SwaggerControllerNameAttribute(string ctrlrName)
        {
            if (string.IsNullOrEmpty(ctrlrName))
            {
                throw new ArgumentNullException("ctrlrName");
            }
            ControllerName = ctrlrName;
        }
    }
