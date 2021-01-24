    public class BindJson : IModelBinder
    {
        public BindJson()
        {
        }
        public virtual object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new SysException("Missing controller context");
            if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                return null;
            controllerContext.HttpContext.Request.InputStream.Position = 0;
            using (var reader = new StreamReader(controllerContext.HttpContext.Request.InputStream))
            {
                var data = reader.ReadToEnd();
                if (!String.IsNullOrEmpty(bodyText))
                {
                    return JsonConvert.DeserializeObject(data, bindingContext.ModelType);
                }
            }
                
            return null;
        }
    }
