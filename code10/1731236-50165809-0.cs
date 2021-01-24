    namespace MyCorp.Api
    {
        public class CustomModelBinder<T> : IModelBinder
        {
            public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
            {
                var settings = new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error
                };
    
                try
                {
                    bindingContext.Model =
                        JsonConvert.DeserializeObject<T>(
                        actionContext.Request.Content.ReadAsStringAsync().Result,
                        settings);
                }
                catch (Exception ex)
                {
                    var split = ex.Message.Split("'".ToCharArray());
                    var message = "{0}.{1} is not a valid property";
                    var formattedMessage = string.Format(message, split[3], split[1]);
                    bindingContext.ModelState.AddModelError("extraProperty", formattedMessage);
                }
                return true;
            }
        }
    }
