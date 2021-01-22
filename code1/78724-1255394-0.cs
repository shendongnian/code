    class Program
    {
        [DllImport(@"..\..\..\Debug\TestCProgram.dll")]
        public static extern void testfunc([In, Out] teststruc[] ts);
        static void Main(string[] args)
        {
            teststruc[] teststructs = new teststruc[6];
            for (int i = 0; i < teststructs.Length; i++)
            {
                teststructs[i].int1 = (i + 1) * 100;
                teststructs[i].int2 = (i + 1) * 100;
            }
            testfunc(teststructs);
            for (int i = 0; i < teststructs.Length; i++)
            {
                Console.WriteLine("Int1 = {0}", teststructs[i].int1);
                Console.WriteLine("Int2 = {0}", teststructs[i].int2);
            }
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct teststruc
    {
        [MarshalAs(UnmanagedType.I4)]
        public int int1;
        [MarshalAs(UnmanagedType.I4)]
        public int int2;
    }
}
