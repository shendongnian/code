    public class Adler32Computer
    {
        private int a = 1;
        private int b = 0;
        public int Checksum
        {
            get
            {
                return ((b * 65536) + a);
            }
        }
        private static readonly int Modulus = 65521;
        public void Update(byte[] data, int offset, int length)
        {
            for (int counter = 0; counter < length; ++counter)
            {
                a = (a + (data[offset + counter])) % Modulus;
                b = (b + a) % Modulus;
            }
        }
    }
