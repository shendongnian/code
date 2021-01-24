        using System;
        using System.Threading.Tasks;
        					
        public class Program
        {
            public class MyEventArgs : EventArgs
            {
                 public int port {get; set; }
    
                 public MyEventArgs(int port)
                 {
                     this.port = port;
                 }
            }
          
            delegate void OpenPort(object sender, MyEventArgs  e);
        	event OpenPort OnOpen;
        	int from = 10, to = 20;
        	int Connected = 16;
            
        	public static void Main()
        	{
        		var obj = new Program();
                // here you register your method ShowPort for OnOpen event. 
        		obj.OnOpen += new OpenPort(ShowPort);
        		for(int i = obj.from; i < obj.to; i++){
        			Task.Run(() => {
        				if(i == obj.w) // here you will try catch your ftp connect method, if it connects then you raise an event.
        				{
        					obj.OnOpen(obj, new MyEventArgs(i));
        				}
        			});	
        		}
        	}
        	
            // This method will be called after connecting.
        	public static void ShowPort(Object p, MyEventArgs args)
        	{
        		Console.WriteLine(args.port);
        	}
        }
