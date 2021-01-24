    public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Test....");
        GetCurrentMethod();
    }
    
    public static string GetCurrentMethod([System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
    {
       System.Diagnostics.Trace.WriteLine("member name: " + memberName);
    }
