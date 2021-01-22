    class Logger{
     private static ILogger _Logger;
    
     static Logger(){
      //DI injection here
      _Logger = new NullLogger(); //or
      _Logger = new TraceLogger();
     }
    }
    
    interface ILogger{
     void Log(string Message);
    }
    
    internal class TraceLogger:ILooger{
     public void Log(string Message){
      //Code here
     }
    }
    
    internal class NullLogger{
     public void Log(string Message){
      //Don't don anything, in purporse
     }
    }
