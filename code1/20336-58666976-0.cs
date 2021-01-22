        // a safe version of the lookup solution:       
        public static string ByteArrayToHexViaLookup32Safe(byte[] bytes, bool withZeroX)
        {
            if (bytes.Length == 0)
            {
                return withZeroX ? "0x0" : "0";
            }
            
            int length = bytes.Length * 2 + (withZeroX ? 2 : 0);
            StateSmall stateToPass = new StateSmall(bytes, withZeroX);
            return string.Create(length, stateToPass, (chars, state) =>
            {
                int offset0x = 0;
                if (state.WithZeroX)
                {
                    chars[0] = '0';
                    chars[1] = 'x';
                    offset0x += 2;
                }
                Span<uint> charsAsInts = MemoryMarshal.Cast<char, uint>(chars.Slice(offset0x));
                int targetLength = state.Bytes.Length;
                for (int i = 0; i < targetLength; i += 1)
                {
                    uint val = Lookup32[state.Bytes[i]];
                    charsAsInts[i] = val;
                }
            });
        }
        private struct StateSmall
        {
            public StateSmall(byte[] bytes, bool withZeroX)
            {
                Bytes = bytes;
                WithZeroX = withZeroX;
            }
            
            public byte[] Bytes;
            public bool WithZeroX;
        }
