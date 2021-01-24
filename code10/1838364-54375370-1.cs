        // Converts a Span into a double
        // Requires using System.Runtime.CompilerServices.Unsafe
        public static double ToDouble(ReadOnlySpan<byte> value)
        {
            if (value.Length < sizeof(double))
                throw new ArgumentOutOfRangeException(nameof(value));
            return Unsafe.ReadUnaligned<double>(ref MemoryMarshal.GetReference(value));
        }
