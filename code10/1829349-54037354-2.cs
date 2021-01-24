    public class A : IEnumerable<C>
    {
        private List<C> Plist { get; set; } = new List<C>();
        public IEnumerator<C> GetEnumerator()
        {
            return ((IEnumerable<C>)Plist).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<C>)Plist).GetEnumerator();
        }
    }
    public class B
    {
        public void SomeMethod()
        {
            A a = new A();
            a.Where(i => i.AnotherListInC.Contains(SomeObject));
            a.Any(i => i.AnotherListInC.Contains(SomeObject));
        }
    }
