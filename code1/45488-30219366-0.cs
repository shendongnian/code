        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Log(object message) {
    #if DEBUG
            Console.WriteLine(message);
    #endif
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Log(string format, params object[] args) {
    #if DEBUG
            Console.WriteLine(format, args);
    #endif
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Square(double x) {
            return x * x;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void ClearBuffer(ref byte[] buffer) {
            ClearBuffer(ref buffer, 0, buffer.Length);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void ClearBuffer(ref byte[] buffer, int offset, int length) {
            fixed(byte* ptrBuffer = &buffer[offset]) {
                for(int i = 0; i < length; ++i) {
                    *(ptrBuffer + i) = 0;
                }
            }
        }
