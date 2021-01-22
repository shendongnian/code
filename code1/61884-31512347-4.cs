    [StructLayout(LayoutKind.Sequential)]
    public class ShallowCloneTest
    {
        public int Foo;
        public long Bar;
        public ShallowCloneTest Clone()
        {
            return (ShallowCloneTest)base.MemberwiseClone();
        }
    }
