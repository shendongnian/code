    using System.Runtime.InteropServices;
    public class MY_PINVOKES
    {
        [DllImport("some.dll")]
        private static void SomeMethod();
        [DllImport("some.dll")]
        private static void SomeMethod2();
    }
