    [assembly: DebuggerTypeProxy(typeof(ByteArrayHexView), Target = typeof(byte[]))]
    [assembly: DebuggerTypeProxy(typeof(ByteHexView), Target = typeof(byte))]
    
    public class ByteArrayHexView
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte[] array;
    
        public string Hex => String.Join(", ", array.Select(x => $"0x{x:X2}"));
    
        public ByteArrayHexView(byte[] array)
        {
            this.array = array;
        }
    }
    
    public class ByteHexView
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte value;
    
        public string Hex => $"0x{value:X2}";
    
        public ByteHexView(byte value)
        {
            this.value = value;
        }
    }
