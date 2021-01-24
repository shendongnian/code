    [DllImport("CPlusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern CallbacksPtr GetServerPluginInterface();
    [StructLayout(LayoutKind.Sequential)]
    public struct CallbacksPtr
    {
        public IntPtr Ptr;
    }
    public class Callbacks
    {
        public static implicit operator Callbacks(CallbacksPtr ptr)
        {
            return new Callbacks(ptr.Ptr);
        }
        private Callbacks(IntPtr ptr)
        {
            ...
    }
