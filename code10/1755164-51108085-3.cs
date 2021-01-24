    public class A
    {
        public string Name {get; set;}
        public List<A> ListOfA {get; set;}
        public List<B> ListOfB {get; set;}
        public IList Children
        {
            get
            {
                return new CompositeCollection()
                {
                    new CollectionContainer() { Collection = ListOfA },
                    new CollectionContainer() { Collection = ListOfB }
                };
            }
        }
    }
    public class B
    {
        public string Name {get; set;}
        public List<C> ListOfC {get; set;}
        public List<D> ListOfD {get; set;}
        public IList Children
        {
            get
            {
                return new CompositeCollection()
                {
                    new CollectionContainer() { Collection = ListOfC },
                    new CollectionContainer() { Collection = ListOfD }
                };
            }
        }
    }
    public class C
    {
        public string Name {get; set;} 
        public List<D> ListOfD {get; set;}
    }
    public class D
    {
        public string Name{get; set;}
    }
