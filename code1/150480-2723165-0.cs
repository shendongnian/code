    class Test
    {
        public unsafe static void Main(string[] args)
        {
            byte[] bytes = new byte[] {70, 40, 30, 51, 0};
            fixed(byte* ptr = bytes)
            {
                int len = strlen(ptr);
                Console.WriteLine(len);
            }
        }
        [DllImport("msvcrt.dll")]
        private unsafe static extern int strlen(byte* pByte);       
    }
