    class Program
        {
            [DllImport("TestCppLib.dll", CharSet = CharSet.Ansi, EntryPoint = "?fnTestCppLib@@YAHPAPAD@Z", CallingConvention=CallingConvention.Cdecl)]
            extern static int fnTestCppLib(ref string s);
            static void Main(string[] args)
            {
                var s = "some";
                var t = fnTestCppLib(ref s);
                Debug.Assert(s == "test");
            }
        }
