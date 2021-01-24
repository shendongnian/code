    public class ContainsTranslationDefinition : Attribute
    { }
    /// <summary>
    /// Creates the namespace for a popup window and has an additional flag for the caption
    /// </summary>
    public class LanguagePopupMessage
    {
        public string Namespace { get; }
        public string Caption => $"{Namespace}Caption";
        public LanguagePopupMessage(string fieldName)
        {
            if(string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException(nameof(fieldName));
            if (_GetNamespace() is Type type)
            {
                Namespace = $"{type}.{fieldName}";
            }
            else
            {
                throw new InvalidOperationException("could not fetch the namespace");
            }
        }
        private Type _GetNamespace()
        {
            StackTrace st = new StackTrace();
            foreach (var sf in st.GetFrames())
            {
                var type = sf.GetMethod().DeclaringType;
                if (type != GetType())
                {
                    return type;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return $"Namespace '{Namespace}' Caption '{Caption}'";
        }
    }
    /// <summary>
    /// Add <see cref="LanguagePopupMessage"/> into the <see cref="Container.Model"/> type lifecycle
    /// </summary>
    public class FindAllLanguagePopupMessages : IRegistrationConvention
    {
        private readonly ILifecycle _Lifecycle = new UniquePerRequestLifecycle();
        public void ScanTypes(TypeSet types, Registry registry)
        {
            List<LanguagePopupMessage> dec = new List<LanguagePopupMessage>();
            foreach (Type type in types.AllTypes())
            {
                if (!Attribute.IsDefined(type, typeof(ContainsTranslationDefinition)))
                {
                    continue;
                }
                _FindConfigDeclarations(type, dec);
            }
            foreach (LanguagePopupMessage languagePopupMessage in dec)
            {
                Console.WriteLine($"{languagePopupMessage}");
            }
        }
        private static void _FindConfigDeclarations(Type type, List<LanguagePopupMessage> declarations)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            declarations.AddRange(fields
                .Where(info => info.IsInitOnly && typeof(LanguagePopupMessage).IsAssignableFrom(info.FieldType))
                .Select(info => (LanguagePopupMessage)info.GetValue(null)));
            // find all nested class types and run method recursively
            foreach (var nestedType in type.GetNestedTypes(BindingFlags.Public))
            {
                _FindConfigDeclarations(nestedType, declarations);
            }
        }
    }
    [ContainsTranslationDefinition]
    public class TestClass
    {
        private static readonly LanguagePopupMessage _CONFIG_1 = new LanguagePopupMessage("ConfigNotLoaded1");
        private static readonly LanguagePopupMessage _CONFIG_2 = new LanguagePopupMessage("ConfigNotLoaded2");
    }
    [ContainsTranslationDefinition]
    public class Program
    {
        //ConsoleApp1.Program.PopupMessage.ConfigNotLoaded
        //ConsoleApp1.Program.PopupMessage.ConfigNotLoadedCaption
        private static readonly LanguagePopupMessage _CONFIG_NOT_LOADED_POPUP_MESSAGE = new LanguagePopupMessage("ConfigNotLoaded3");
        static void Main(string[] args)
        {
            // Create container and tell where to look for depencies
            IContainer container = new Container(c => c.Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
                scanner.AssembliesFromApplicationBaseDirectory();
                scanner.With(new FindAllLanguagePopupMessages());
            }));
            Console.ReadKey();
        }
    }
