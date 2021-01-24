    public class ContainerClass
    {
        private MyClass myClass;
        public IMyClassPublic myClassPublic
        {
            get
            {
                return myClass;
            }
        }
        internal IMyClassInternal myClassInternal
        {
            get
            {
                return myClass;
            }
        }
    }
