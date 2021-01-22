    using Newtonsoft.Json;
    
    namespace MySite.Web
    {
        public class MyModelBinder : IModelBinder
        {
            // make a new Json serializer
            protected static JsonSerializer jsonSerializer = null;
    
            static MyModelBinder()
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                // Set custom serialization settings.
                settings.DateTimeZoneHandling= DateTimeZoneHandling.Utc;
                jsonSerializer = JsonSerializer.Create(settings);
            }
    
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                object model;
    
                if (bindingContext.ModelType.Assembly == "MyDtoAssembly")
                {
                    var s = controllerContext.RequestContext.HttpContext.Request.InputStream;
                    s.Seek(0, SeekOrigin.Begin);
                    using (var sw = new StreamReader(s))
                    {
                        model = jsonSerializer.Deserialize(sw, bindingContext.ModelType);
                    }
                }
                else
                {
                    model = ModelBinders.Binders.DefaultBinder.BindModel(controllerContext, bindingContext);
                }
                return model;
            }
        }
    }
