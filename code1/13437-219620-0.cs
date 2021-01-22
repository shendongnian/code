    using System;
    using System.Text;
    
    public class Hex
    {
        static void Main()
        {
            string original = "The quick brown fox jumps over the lazy dog.";
            
            byte[] binary = Encoding.UTF8.GetBytes(original);
            string hex = BytesToHex(binary);
            Console.WriteLine("Hex: {0}", hex);
            byte[] backToBinary = HexToBytes(hex);
            
            string restored = Encoding.UTF8.GetString(backToBinary);
            Console.WriteLine("Restored: {0}", restored);
        }
        
        private static readonly char[] HexChars = "0123456789ABCDEF".ToCharArray();
        
        public static string BytesToHex(byte[] data)
        {
            StringBuilder builder = new StringBuilder(data.Length*2);
            foreach(byte b in data)
            {
                builder.Append(HexChars[b >> 4]);
                builder.Append(HexChars[b & 0xf]);
            }
            return builder.ToString();
        }
        
        public static byte[] HexToBytes(string text)
        {
            if ((text.Length & 1) != 0)
            {
                throw new ArgumentException("Invalid hex: odd length");
            }
            byte[] ret = new byte[text.Length/2];
            for (int i=0; i < text.Length; i += 2)
            {
                ret[i/2] = (byte)(ParseNybble(text[i]) << 4 | ParseNybble(text[i+1]));
            }
            return ret;
        }
        
        private static int ParseNybble(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return c-'0';
            }
            if (c >= 'A' && c <= 'F')
            {
                return c-'A'+10;
            }
            if (c >= 'a' && c <= 'f')
            {
                return c-'A'+10;
            }
            throw new ArgumentOutOfRangeException("Invalid hex digit: " + c);
        }
    }
