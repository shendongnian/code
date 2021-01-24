    public class TestClass
    {
        private SomeClass sc;
        private AnotherClass ac;
    
        public TestClass()
        {
            var type = GetType();
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(x => x.Name)
                .ToList()
                .ForEach(f => {
                    type.GetField(f).SetValue(this, Activator.CreateInstance(f.GetType());
                });
        }
    }
