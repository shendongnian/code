            static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Stop();
            Console.WriteLine("Reflection Result:");
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                //Using reflection to get the current method name.
                PassedName(MethodBase.GetCurrentMethod().Name);
            }
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("StackFrame Result");
            sw.Restart();
            
            for (int i = 0; i < 1000000; i++)
            {
                UsingStackFrame();
            }
            
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("CallerMemberName attribute Result:");
            
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                UsingCallerAttribute();
            }
            
            Console.WriteLine(sw.Elapsed);
            
            sw.Stop();
            Console.WriteLine("Done");
            Console.Read();
        }
        static void PassedName(string name)
        {
        }
        static void UsingStackFrame()
        {
            string name = new StackFrame(1).GetMethod().Name;
        }
        static void UsingCallerAttribute([CallerMemberName] string memberName = "")
        {
        }
