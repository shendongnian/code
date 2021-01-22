    public static class GrayCode
    {
        public static byte BinaryToByte(BitArray binary)
        {
            if (binary.Length > 8)
                throw new ArgumentException("bitarray too long for byte");
            var array = new byte[1];
            binary.CopyTo(array, 0);
            return array[0];
        }
        public static int BinaryToInt(BitArray binary)
        {
            if (binary.Length > 32)
                throw new ArgumentException("bitarray too long for int");
            var array = new int[1];
            binary.CopyTo(array, 0);
            return array[0];
        }
        public static BitArray BinaryToGray(BitArray binary)
        {
            var len = binary.Length;
            var gray = new BitArray(len);
            gray[len - 1] = binary[len - 1]; // copy high-order bit
            for (var i = len - 2; i >= 0; --i)
            {
                // remaining bits 
                gray[i] = binary[i] ^ binary[i + 1];
            }
            return gray;
        }
        public static BitArray GrayToBinary(BitArray gray)
        {
            var len = gray.Length;
            var binary = new BitArray(len);
            binary[len - 1] = gray[len - 1]; // copy high-order bit
            for (var i = len - 2; i >= 0; --i)
            {
                // remaining bits 
                binary[i] = !gray[i] ^ !binary[i + 1];
            }
            return binary;
        }
        public static BitArray ByteToGray(byte value)
        {
            var bits = new BitArray(new[] { value });
            return BinaryToGray(bits);
        }
        public static BitArray IntToGray(int value)
        {
            var bits = new BitArray(new[] { value });
            return BinaryToGray(bits);
        }
        public static byte GrayToByte(BitArray gray)
        {
            var binary = GrayToBinary(gray);
            return BinaryToByte(binary);
        }
        public static int GrayToInt(BitArray gray)
        {
            var binary = GrayToBinary(gray);
            return BinaryToInt(binary);
        }
        /// <summary>
        ///     Returns the bits as string of '0' and '1' (LSB is right)
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static string AsString(this BitArray bits)
        {
            var sb = new StringBuilder(bits.Length);
            for (var i = bits.Length - 1; i >= 0; i--)
            {
                sb.Append(bits[i] ? "1" : "0");
            }
            return sb.ToString();
        }
        public static IEnumerable<bool> Bits(this BitArray bits)
        {
            return bits.Cast<bool>();
        }
        public static bool[] AsBoolArr(this BitArray bits, int count)
        {
            return bits.Bits().Take(count).ToArray();
        }
    }
