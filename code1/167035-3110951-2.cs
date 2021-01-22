    class Customer { public string Name { get; set; } }    
    class Foo { }
    class CustomerCollection : List<Customer>, IEnumerable<Foo>
    {
        private IList<Foo> foos = new List<Foo>();
        public new IEnumerator<Foo> GetEnumerator()
        {
            return foos.GetEnumerator();
        }
    }
