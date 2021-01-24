    class DerivedClass : Interface
    {
        private readonly Interface _interface;
        public DerivedClass(Interface interface) => _interface = Interface;
        public int PropertyOne => _interface.PropertyOne;
        public string PropertyTwo => _interface.PropertyTwo;
    }
