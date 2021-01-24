    public class LanguageFilterFactory : Attribute, IFilterFactory
    {
        public bool IsReusable => false;
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<IHttpContextAccessor>();
            if (context.HttpContext.Request.Host.ToString().Contains(".com"))
            {
                return new EnglishActionFilter();
            }
            return new RussianActionFilter();
        }
    }
