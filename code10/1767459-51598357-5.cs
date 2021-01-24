    public class CustomModelBinderProvider : IModelBinderProvider  
    {  
        public IModelBinder GetBinder(ModelBinderProviderContext context)  
        {  
            if (context.Metadata.ModelType == typeof(PostModel))  
                return new PostModelBinder();  
  
            return null;  
        }  
    }
