    class LoggerScope:IDisposable {
       static ThreadLocal<LoggerScope> threadScope = 
            new ThreadLocal<LoggerScope>();
       private LoggerScope previous;
       public static LoggerScope Current=> threadScope.Value;
       public bool WithTime{get;}
       public LoggerScope(bool withTime){
           previous = threadScope.Value;
           threadScope.Value = this;
           WithTime=withTime;
       }
       
       public void Dispose(){
           threadScope.Value = previous;
       }
    }
    class Program {
       public static void Main(params string[] args){
           new Program().Run();
       }
       
       public void Run(){
          log("something happend!");
          using(new LoggerScope(false)){
              log("the quick brown fox jumps over the lazy dog!");
              using(new LoggerScope(true)){
                  log("nested scope!");
              }
          }
       }
       
       void log(string message){
          if(LoggerScope.Current!=null){
              Console.WriteLine(message);
              if(LoggerScope.Current.WithTime){
                 Console.WriteLine(DateTime.Now);
              }
          }
       }
    }
