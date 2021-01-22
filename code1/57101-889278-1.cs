    public class ConsoleSpinner : IDisposable
    {       
        public ConsoleSpinner()
        {
            CursorLeft = Console.CursorLeft;
            CursorTop = Console.CursorTop;  
        }
        public ConsoleSpinner(bool start)
            : this()
        {
            if (start) Start();
        }
        public void Start()
        {
            // prevent two conflicting Start() calls ot the same instance
            lock (instanceLocker) 
            {
                if (!running )
                {
                    running = true;
                    turner = new Thread(Turn);
                    turner.Start();
                }
            }
        }
        public void StartHere()
        {
            SetPosition();
            Start();
        }
        public void Stop()
        {
            lock (instanceLocker)
            {
                if (!running) return;
                running = false;
                if (! turner.Join(250))
                    turner.Abort();
            }
        }
        public void SetPosition()
        {
            SetPosition(Console.CursorLeft, Console.CursorTop);
        }
        public void SetPosition(int left, int top)
        {
            bool wasRunning;
            //prevent cursor change during the update
            lock (instanceLocker)
            {
                wasRunning = running;
                Stop();
                CursorLeft = left;
                CursorTop = top;
                if (wasRunning) Start();
            } 
        }
        /* ---  PRIVATE --- */
        private int counter=-1;
        private Thread turner; 
        private bool running = false;
        private int rate = 100;
        private int CursorLeft;
        private int CursorTop;
        private Object instanceLocker = new Object();
        private static Object console = new Object();
        private void Turn()
        {
            while (running)
            {
                // prevent two instances from overlapping cursor position updates
                // weird things can still happen if the main ui thread moves the cursor during an update and context switch
                lock (console)
                {
                    counter++;
                    int OldLeft = Console.CursorLeft;
                    int OldTop = Console.CursorTop;
                    Console.SetCursorPosition(CursorLeft, CursorTop);
                    switch (counter)
                    {
                        case 0: Console.Write("/"); break;
                        case 1: Console.Write("-"); break;
                        case 2: Console.Write("\\"); break;
                        case 3: Console.Write("|"); counter = -1; break;
                    }
                    Console.SetCursorPosition(OldLeft, OldTop);
                }
                Thread.Sleep(rate);
            }
            lock (console)
            {   // clean up
                int OldLeft = Console.CursorLeft;
                int OldTop = Console.CursorTop;
                Console.SetCursorPosition(CursorLeft, CursorTop);
                Console.Write(' ');
                Console.SetCursorPosition(OldLeft, OldTop);
            }
        }
        public void Dispose()
        {
            Stop();
        }
    }
