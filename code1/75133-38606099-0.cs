    public class BitConvert
    {
        [StructLayout(LayoutKind.Explicit)]
        struct EnumUnion32<T> where T : struct {
            [FieldOffset(0)]
            public T Enum;
            [FieldOffset(0)]
            public int Int;
        }
        public static int Enum32ToInt<T>(T e) where T : struct {
            var u = default(EnumUnion32<T>);
            u.Enum = e;
            return u.Int;
        }
        public static T IntToEnum32<T>(int value) where T : struct {
            var u = default(EnumUnion32<T>);
            u.Int = value;
            return u.Enum;
        }
    }
