    public static void LogPacket(string Data)
    {
        using(TextWriter Str = new StreamWriter(@"D:\Titi.txt",true))
        {
            Str.WriteLine(Data);
            Str.WriteLine(Environment.NewLine);
        }
     }
