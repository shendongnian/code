    [StructLayout(LayoutKind.Explicit)]
    public class OverlapEvents
    {
        [FieldOffset(0)]
        public VRInput Source;
        [FieldOffset(0)]
        public EventCapture Target;
    }
