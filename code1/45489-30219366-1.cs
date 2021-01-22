            /// <summary>
            /// Prints a message when in debug mode
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static unsafe void Log(object message) {
    #if DEBUG
                Console.WriteLine(message);
    #endif
            }
            /// <summary>
            /// Prints a formatted message when in debug mode
            /// </summary>
            /// <param name="format">A composite format string</param>
            /// <param name="args">An array of objects to write using format</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static unsafe void Log(string format, params object[] args) {
    #if DEBUG
                Console.WriteLine(format, args);
    #endif
            }
            /// <summary>
            /// Computes the square of a number
            /// </summary>
            /// <param name="x">The value</param>
            /// <returns>x * x</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static double Square(double x) {
                return x * x;
            }
            /// <summary>
            /// Wipes a region of memory
            /// </summary>
            /// <param name="buffer">The buffer</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static unsafe void ClearBuffer(ref byte[] buffer) {
                ClearBuffer(ref buffer, 0, buffer.Length);
            }
            /// <summary>
            /// Wipes a region of memory
            /// </summary>
            /// <param name="buffer">The buffer</param>
            /// <param name="offset">Start index</param>
            /// <param name="length">Number of bytes to clear</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static unsafe void ClearBuffer(ref byte[] buffer, int offset, int length) {
                fixed(byte* ptrBuffer = &buffer[offset]) {
                    for(int i = 0; i < length; ++i) {
                        *(ptrBuffer + i) = 0;
                    }
                }
            }
