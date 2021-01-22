    public class DynamicXamlLoader : MarkupExtension
    {
        public DynamicXamlLoader() { }
        public DynamicXamlLoader(string xamlFileName)
        {
            XamlFileName = xamlFileName;
        }
        public string XamlFileName { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValue = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (provideValue == null || provideValue.TargetObject == null) return null;
            // get target
            var targetObject = provideValue.TargetObject as UIElement;
            if (targetObject == null) return null;
            // get xaml file
            var xamlFile = new DirectoryInfo(Directory.GetCurrentDirectory())
                .GetFiles(XamlFileName ?? GenerateXamlName(targetObject), SearchOption.AllDirectories)
                .FirstOrDefault();
            if (xamlFile == null) return null;
            // load xaml
            using (var reader = new StreamReader(xamlFile.FullName))
                return XamlReader.Load(reader.BaseStream) as UIElement;
        }
        private static string GenerateXamlName(UIElement targetObject)
        {
            return string.Concat(targetObject.GetType().Name, ".xaml");
        }
    }
