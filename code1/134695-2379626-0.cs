     interface ITest
    {
        void MethodOne();
        [InterfaceVersion(2)]
        void MethodTwo();
    }
    [AttributeUsage(AttributeTargets.All)]
    public class InterfaceVersion : System.Attribute
    {
        public readonly int N;
        public InterfaceVersion(int n) 
        {
            this.N = n;
        }
    }
