    public class A : BaseRegistryGetter<A>
    {
        public A(string name) : base(name)
        {
        }
        public static A GetA(string instanceName)
        {
            return BaseRegistryGetter<A>.GetValue(instanceName, s => new A(s));
        }
    }
