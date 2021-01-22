    public class FloatingPointReset
    {
        [DllImport("msvcr110.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _fpreset();
        public static void Action()
        {
            // Reset the Floating Point (When called from External Application there was an Overflow exception)
            _fpreset();
        }
    }
