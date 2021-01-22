    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    namespace EventLogger
    {
        class Program
        {
            static void Main(string[] args)
            {            		
                // Event handler
                LogData ld = new LogData();
                // Logger
                Logger lo = new Logger();                    
                // Subscribe to event
                ld.MyEvent += lo.OnMyEvent;		
                // Thread loop
                int cnt = 1;
                while(cnt < 5){			
                    Thread t = new Thread(() => RunMe(cnt, ld));
                    t.Start();
                    cnt++;
                }
                Console.WriteLine("While end");
            }
            // Thread worker
            public static void RunMe(int cnt, LogData ld){
                int nr = 0;
                while(true){
                    nr++;
                    // Add user and fire event
                    ld.AddToLog(new User(){Name = "Log to file Thread" + cnt + " Count " + nr, Email = "em@em.xx"});
                    Thread.Sleep(1);
                }
            }
        }
        class LogData
        {
            public delegate void MyEventHandler(object o, User u);
            public event MyEventHandler MyEvent;
            
            protected virtual void OnEvent(User u)
            {
                if(MyEvent != null){
                    MyEvent(this, u);
                }
                
            }
            // Wywołaj
            public void AddToLog(User u){
                Console.WriteLine("Add to log.");
                // Odpal event
                OnEvent(u);
                Console.WriteLine("Added.");
            }
        }
        class User
        {
            public string Name = "";
            public string Email =  "";
        }
        class Logger
        {
            // Catch event
            public void OnMyEvent(object o, User u){
                try{
                    Console.WriteLine("Added to file log! " + u.Name + " " + u.Email);
                    File.AppendAllText(@"event.log", "Added to file log! " + u.Name + " " + u.Email+"\r\n");
                }catch(Exception e){
                    Console.WriteLine("Error file log " + e);
                }
            }
        }
    }
