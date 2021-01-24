    public class TestClass
    {
        private SomeClass sc;
        private AnotherClass ac;
    
        public TestClass()
        {
            var type = GetType();
            type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .ToList()
                .ForEach(f => {
                    f.SetValue(this, Activator.CreateInstance(f.FieldType);
                });
        }
    }
