    public class EmbededServerDataBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) { throw new ArgumentNullException(nameof(bindingContext)); }
            var modelName = bindingContext.BinderModelName ?? "ServerData";
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var data= bindingContext.HttpContext.Request.Form.Files[modelName];
            if(data == null){ 
                bindingContext.ModelState.AddModelError(modelName,"invalid error");
                return Task.CompletedTask;
            }
            using(var stream = data.OpenReadStream()){
                var o = serializer.Deserialize(stream);
                bindingContext.Result = ModelBindingResult.Success(o);
            }
            return Task.CompletedTask;
        }
    }
