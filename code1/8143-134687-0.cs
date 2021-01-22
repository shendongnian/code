    using System;
    using System.Threading;
    
    public class Example
    {
        private int nValue;
        public int N { get { return nValue; } }
    
        // The Hash property is slower because it clones an array. When
        // KeepAlive is not used, the finalizer sometimes runs before 
        // the Hash property value is read.
    
        private byte[] hashValue;
        public byte[] Hash { get { return (byte[])hashValue.Clone(); } }
        public byte[] Hash2 { get { return (byte[])hashValue; } }
    
        public int returnNothing() { return 25; }
    
        public Example()
        {
            nValue = 2;
            hashValue = new byte[20];
            hashValue[0] = 2;
        }
    
        ~Example()
        {
            nValue = 0;
    
            if (hashValue != null)
            {
                Array.Clear(hashValue, 0, hashValue.Length);
            }
        }
    }
    
    public class Test
    {
        private static int totalCount = 0;
        private static int finalizerFirstCount = 0;
    
        // This variable controls the thread that runs the demo.
        private static bool running = true;
    
        // In order to demonstrate the finalizer running first, the
        // DoWork method must create an Example object and invoke its
        // Hash property. If there are no other calls to members of
        // the Example object in DoWork, garbage collection reclaims
        // the Example object aggressively. Sometimes this means that
        // the finalizer runs before the call to the Hash property
        // completes. 
    
        private static void DoWork()
        {
            totalCount++;
    
            // Create an Example object and save the value of the 
            // Hash property. There are no more calls to members of 
            // the object in the DoWork method, so it is available
            // for aggressive garbage collection.
    
            Example ex = new Example();
    
            // Normal processing
            byte[] res = ex.Hash;
    
            // Supposed inlined processing
            //byte[] res2 = ex.Hash2;
            //byte[] res = (byte[])res2.Clone();
    
            // successful try to keep reference alive
            //ex.returnNothing();
    
            // Failed try to keep reference alive
            //ex = null;
    
            // If the finalizer runs before the call to the Hash 
            // property completes, the hashValue array might be
            // cleared before the property value is read. The 
            // following test detects that.
    
            if (res[0] != 2)
            {
                finalizerFirstCount++;
                Console.WriteLine("The finalizer ran first at {0} iterations.", totalCount);
            }
    
            //GC.KeepAlive(ex);
        }
    
        public static void Main(string[] args)
        {
            Console.WriteLine("Test:");
    
            // Create a thread to run the test.
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
    
            // The thread runs until Enter is pressed.
            Console.WriteLine("Press Enter to stop the program.");
            Console.ReadLine();
    
            running = false;
    
            // Wait for the thread to end.
            t.Join();
    
            Console.WriteLine("{0} iterations total; the finalizer ran first {1} times.", totalCount, finalizerFirstCount);
        }
    
        private static void ThreadProc()
        {
            while (running) DoWork();
        }
    }
