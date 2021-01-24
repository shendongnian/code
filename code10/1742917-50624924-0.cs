    namespace Framework
    {
        public class ExampleClass
        {
            private readonly IUsesExternalDll _usesExternalDll;
    
            public ExampleClass([Optional] IUsesExternalDll usesExternalDll)
            {
                _usesExternalDll = usesExternalDll;
            }
        }
    }
