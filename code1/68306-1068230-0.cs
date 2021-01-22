    static void Main() {
        object lockObj = new object();
        lock (lockObj) {
            new Thread(GetInput).Start(lockObj);
            Monitor.Wait(lockObj, 10000);
        }
        Console.WriteLine("Main exiting");
    }
    static void GetInput(object state) {
        Console.WriteLine("press return...");
        string s = Console.ReadLine();
        lock (state) {
            Monitor.Pulse(state);
        }
        Console.WriteLine("GetInput exiting");
    }
