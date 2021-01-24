    static void Main(string[] args)
    {
        Console.WriteLine("imput url ");
        string stringImput = Console.ReadLine();
        string BinaryString = (ToBinaryString(Encoding.UTF8, stringImput));
        Console.WriteLine(BinaryString);
        ToSoundString(BinaryString);
        Console.ReadLine();
    }
    static string ToBinaryString(Encoding encoding, string text)
    {
        return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
    }
        public static void ToSoundString(string message)
        {
            message.ToList().ForEach(f =>
            {
                switch (f)
                {
                    case '0':
                        Console.Beep(500, 100);
                        break;
                    case '1':
                        Console.Beep(800, 100);
                        break;
                }
            });
        }
