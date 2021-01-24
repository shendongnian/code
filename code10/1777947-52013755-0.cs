    [ContentProperty(nameof(TheType))]
    public class TypeMarkupExtension : IMarkupExtension
    {
        public string TheType { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(TheType))
                throw new InvalidOperationException("TheType isn't set.");
            
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            var typeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (typeResolver == null)
                throw new ArgumentException("No IXamlTypeResolver in IServiceProvider");
            var resolvedType = typeResolver.Resolve(TheType, serviceProvider);
            return resolvedType?.FullName ?? "Failure";
        }
    }
