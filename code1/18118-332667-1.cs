    public static class Extensions
    {
        public static int IndexOfSequence(this byte[] buffer, byte[] pattern)
        {
            return IndexOfSequence(buffer, pattern, 0);
        }
        public static int IndexOfSequence(this byte[] buffer, byte[] pattern, 
                                          int startIndex)
        {
            int i = Array.IndexOf(buffer, pattern[pattern.Length - 1], 
                                  startIndex + pattern.Length - 1);
            while (i < buffer.Length && i >= 0)
            {
                int count = 0;
                int pos = 0;
                foreach (byte b in pattern.Reverse())
                {
                    pos = Array.IndexOf(buffer, b, i);
                    if (pos == i)
                    {
                        i--;
                        count++;
                    }
                    else if (pos == -1)
                    {
                        i = -1;
                        break;
                    }
                    else
                    {
                        i = pos + count;
                        break;
                    }
                }
                if (count == pattern.Length || i == -1)
                {
                    i = pos;
                    break;
                }
                i = Array.IndexOf(buffer, pattern[pattern.Length - 1], i);
            }
            return i;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer = new byte[] { 0x0a, 0x0b, 0x01, 0x02, 0x10, 0x20, 0x0a, 0x0b, 
                                         0x01, 0x02, 0x10, 0x01, 0x0b, 0xcc, 0xcd, 0xcc, 
                                         0xcd, 0x0b, 0x12, 0xd0, 0x33, 0xc1, 0xcc, 0x01 };
            byte[] pattern1 = new byte[] { 0x0a};               // Answer 0
            byte[] pattern2 = new byte[] { 0x02, 0x10 };        // Answer 3
            byte[] pattern3 = new byte[] { 0xcc, 0xcd };        // Answer 13 or 
                                                                // 15 if starting at 14
            byte[] pattern4 = new byte[] { 0xcc, 0xcd, 0x0b };  // Answer 15
            int index = buffer.IndexOfSequence(pattern1);
            Console.WriteLine(index.ToString());
            index = buffer.IndexOfSequence(pattern2);
            Console.WriteLine(index.ToString());
            index = buffer.IndexOfSequence(pattern3);
            Console.WriteLine(index.ToString());
            index = buffer.IndexOfSequence(pattern3, 14);
            Console.WriteLine(index.ToString());
            index = buffer.IndexOfSequence(pattern4);
            Console.WriteLine(index.ToString());
            Console.ReadLine();
        }
    }
