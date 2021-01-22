    // Using System.Diagnostics
        static void Main(string[] args)
        {
            try
            {
                ThrowError();
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace(e);
                StackFrame lastCallFrame = st.GetFrame(0);
                Console.WriteLine("Error in " + lastCallFrame.GetMethod().Name + " at IL offset 0x" + lastCallFrame.GetILOffset().ToString("x"));
            }
            Console.ReadLine();
        }
        static void ThrowError()
        {
            int i = 999;
            if (Environment.CommandLine != "") // Just anything that returns true but prevents the compiler from optimizing the "i -= 55;" away.
            {
                throw (new Exception());
            }
            i -= 55;
        }
