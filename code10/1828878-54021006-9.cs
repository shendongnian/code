    public class A: Base
    {
        public A(string instanceName)
            :base(instanceName)
        {
        }
        public static A GetA(string instanceName)
            => GetBase(instanceName, () => new A(instanceName)) as A;
    }
    public class B: Base
    {
        public B(string instanceName)
            :base(instanceName)
        {
        }
        public static B GetB(string instanceName)
            => GetBase(instanceName, () => new B(instanceName)) as B;
    }
