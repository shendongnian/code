    class Program
    {
        static void Main()
        {
            int[] i = { -1 };
            RGB rgb = i[0];
        }
    }
    [StructLayout( LayoutKind.Explicit)]
    public struct RGB
    {
        public RGB(int value) {
            this.R = this.G = this.B = 0; this.Value = value;
        }
        [FieldOffset(0)]
        public int Value;
        [FieldOffset(2)]
        public byte R;
        [FieldOffset(1)]
        public byte G;
        [FieldOffset(0)]
        public byte B;
    
        public static implicit operator RGB(int value) {
            return new RGB(value);
        }
        public static implicit operator int(RGB value) {
            return value.Value;
        }
    }
