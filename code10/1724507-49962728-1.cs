    public class ClassThatUsesMockedClass
    {
        private readonly IIterface _other;
        public ClassThatUsesMockedClass(IIterface other)
        {
            _other = other;
        }
        public void DoSomeStuff()
        {
            _other.MethodThatShouldWorkAsAlways();
            _other.MethodToBeTested(5);
        }
    }
