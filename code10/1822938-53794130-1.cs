    public class Bar : IFoo
    {
        private Foo secretFoo;
        public string Name {
            get
            {
                return secretFoo.Name;
            }
        }
    }
