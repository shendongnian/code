        class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(); 
            server.ServerStatusChanged += new EventHandler(ProcessServerStatus); 
            //server.ServerStatus = true; 
            server.ServerStatus = false; 
            Console.Read();
        }
        public class Server
        {
            public event EventHandler ServerStatusChanged; 
            private bool _ServerStatus = false;
            private bool _initialized = false;
            public bool ServerStatus
            {
                get { return this._ServerStatus; }
                set
                {
                    if (this._initialized == true && this._ServerStatus == value)
                        return; // Dont need to do anything;                
                    else
                        this._initialized = true;
                    if (this.ServerStatusChanged != null) // make sure the invocation list is not empty                      
                        ServerStatusChanged(value, new EventArgs());  // Firing Event                
                    this._ServerStatus = value;
                }
            }
        }
        public static void ProcessServerStatus(object sender, EventArgs e)
        {
            bool status = (bool)sender;
            if (status)
                Console.WriteLine("Server is up and running");
            else Console.WriteLine("Server is down, We are working on it it will be back soon");
        }
    }
