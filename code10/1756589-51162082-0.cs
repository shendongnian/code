    class Program
    {
        static void Main(string[] args)
        {
            List<byte[]> list = new List<byte[]>();
            list.Add(new byte[]{0x54, 0x45, 0x53, 0x54, 0x20}); //AKA header[0] represents the hex integers for Test_  where _ is a space
            list.Add(new byte[]{0x0});                          // so the char would be null
            list.Add(new byte[]{ 0x4a, 0x41, 0x53 });           // would be JAS
            foreach (var b in list)
            {
                var chars = Encoding.ASCII.GetChars(b);
                var s = new string(chars);
                Console.WriteLine(s);
            }
        }
    }
