    //using System.Runtime.CompilerServices;
    public void SendError(string Message, [CallerMemberName] string callerName = "") 
    { 
        Console.WriteLine(callerName + "called me."); 
    } 
