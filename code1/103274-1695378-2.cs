    using System;
    
    class Example
    {
        static void Main()
        {
            Work w = new Work();
            w.NewStatus += addStatus;
            w.OtherStatus += addStatus;
            w.DoWork();
        }    
        static void addStatus(String status)
        {
            Console.WriteLine(status);
        }
        static void addStatus(Int32 status)
        {
            Console.WriteLine(status);
        }
    }
    
    class Work
    {
        public event Status<String> NewStatus;
        public event Status<Int32> OtherStatus;
        public delegate void Status<T>(T status);
    
        public void DoWork()
        {
            NewStatus("Work Done");
            OtherStatus(42);
        }
    }
