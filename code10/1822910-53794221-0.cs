    using System.Runtime.InteropServices;
    
    public struct TestValue {int value; }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct TestArray {
       [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst=128)] public TestValue[] s1;
    }
    
    public class Foo
    {
        void test()
        {
            TestArray test = new TestArray();
            test.s1[10] = new TestValue();
        }
    }
