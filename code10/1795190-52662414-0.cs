    public static class PacketLog
    {
       public static TextWriter Str = new StreamWriter(@"D:\Titi.txt",true);
        public static void LogPacket(string Data)
        {
            Str.WriteLine(Data);
            Str.WriteLine(Environment.NewLine);
        }
        public static void CloseLog()
        {
            Str.Close();
        }
    }
