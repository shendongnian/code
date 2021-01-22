        /// <summary>
        /// Decodes a hex string, ignoring all non-hex characters, and stores
        /// the decodes series of bytes into the shared buffer. This returns
        /// the number of bytes that were decoded.
        /// <para>Hex characters are [0-9, a-f, A-F].</para>
        /// </summary>
        /// <param name="hexString">String to parse into bytes.</param>
        /// <param name="buffer">Buffer into which to store the decoded binary data.</param>
        /// <returns>The number of bytes decoded.</returns>
        private static int DecodeHexIntoBuffer(string hexString, byte[] buffer)
        {
            int count = 0;
            bool haveFirst = false;
            bool haveSecond = false;
            char first = '0';
            char second = '0';
            for (int i = 0; i < hexString.Length; i++)
            {
                if (!haveFirst)
                {
                    first = hexString[i];
                    haveFirst = char.IsLetterOrDigit(first);
                    // we have to continue to the next iteration
                    // or we will miss characters
                    continue;
                }
                if (!haveSecond)
                {
                    second = hexString[i];
                    haveSecond = char.IsLetterOrDigit(second);
                }
                if (haveFirst && haveSecond)
                {
                    string hex = "" + first + second;
                    byte nextByte;
                    if (byte.TryParse(hex, NumberStyles.HexNumber, null, out nextByte))
                    {
                        // store the decoded byte into the next slot of the buffer
                        buffer[count++] = nextByte;
                    }
                    // reset the flags
                    haveFirst = haveSecond = false;
                }
            }
            return count;
        }
