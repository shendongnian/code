    public class PostModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            string valueFromBody = string.Empty;
            using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody = sr.ReadToEnd();
            }
            if (string.IsNullOrEmpty(valueFromBody))
            {
                return Task.CompletedTask;
            }
            string idString = Convert.ToString(((JValue)JObject.Parse(valueFromBody)["id"]).Value);
            string categoryString = Convert.ToString(((JValue)JObject.Parse(valueFromBody)["category"]).Value);
            if (string.IsNullOrEmpty(idString) || !int.TryParse(idString, out int id))
            {
                return Task.CompletedTask;
            }
            Category? category = null;
            if(Enum.TryParse(categoryString, out Category parsedCategory))
            {
                category = parsedCategory;
            }
            bindingContext.Result = ModelBindingResult.Success(new PostModel()
            {
                Id = id,
                Category = category
            });
            return Task.CompletedTask;
        }
    }
