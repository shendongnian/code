    using System.Threading;
    class Program
    {
        static int lastId = 0;
    
        static int generateId()
        {
            return Interlocked.Increment(ref lastId);
        }
        // Remainder of Program unchanged
    }
