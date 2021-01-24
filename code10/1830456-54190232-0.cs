    public class BlahTypeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var json = ExtractRequestJson(bindingContext.ActionContext);
            var jObject = Newtonsoft.Json.Linq.JObject.Parse(json);
            var whatTypeInt = (int)jObject.SelectToken("WhatType");
            if (whatTypeInt == 1)
            {
                var obj = DeserializeObject<A>(json);
                bindingContext.Result = ModelBindingResult.Success(obj);
            }
            else if (whatTypeInt == 2)
            {
                var obj = DeserializeObject<B>(json);
                bindingContext.Result = ModelBindingResult.Success(obj);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
        private static string ExtractRequestJson(ActionContext actionContext)
        {
            var content = actionContext.HttpContext.Request.Body;
            return new StreamReader(content).ReadToEnd();
        }
        private static T DeserializeObject<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });
        }
    }
