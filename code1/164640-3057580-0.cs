    // C#
    class ManagedEntryPoint {
       
        [DllImport("core", CallingConvention=CallingConvention.Cdecl)]
        static extern void NativeEntryPoint(Func<int, int, float> helper);
        static float Helper(int, int) { ... }
       
        static void Main() {
            NativeEntryPoint(Helper);
        }
    }
    // C
    void NativeEntryPoint(float (*helper)(int, int)) {
        float x = helper(1, 2);
        ...
    }
