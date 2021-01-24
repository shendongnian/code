    public class A
    {
        private List<C> Plist { get; set; } = new List<C>();
        public IEnumerable<C> Search(Func<C, bool> predicate)
        {
            return this.Plist.Where(predicate);
        }
    }
    public class B
    {
        public void SomeMethod()
        {
            A a = new A();
            a.Search(i => i.AnotherListInC.Contains(SomeObject));
        }
    }
