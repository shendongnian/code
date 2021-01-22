    // Using System.Diagnostics
    static void Main(string[] args)
    {
        try { ThrowError(); }
        catch (Exception e)
        {
            StackTrace st = new System.Diagnostics.StackTrace(e);
            string stackTrace = "";
            foreach (StackFrame frame in st.GetFrames())
            {
                stackTrace = "at " + frame.GetMethod().Name + "  IL offset: 0x" + frame.GetILOffset().ToString("x") + "\n" + stackTrace;
            }
            Console.Write(stackTrace);
            Console.WriteLine("Message: " + e.Message);
        }
        Console.ReadLine();
    }
    static void ThrowError()
    {
        DateTime myDateTime = new DateTime();
        myDateTime = new DateTime(2000, 5555555, 1); // won't work
        Console.WriteLine(myDateTime.ToString());
    }
