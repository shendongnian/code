    public class SomeClass
    {
        public IMetaProperty<string> FirstName { get; private set; }
        public IMetaProperty<string> LastName { get; private set; }
        public IMetaProperty<int> Age { get; private set; }
        public SomeClass() { MetaProperty.Inject(this); }
    }
