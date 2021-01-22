    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Working... ");
            int spinIndex = 0;
            while (true)
            {
                // obfuscate FTW! Let's hope overflow is disabled or testers are impatient
                Console.Write("\b" + @"/-\|"[(spinIndex++) & 3]);
            }
        }
    }
