    public static class AlignedNew
    {
        public static T New<T>() where T : new()
        {
            LinkedList<T> candidates = new LinkedList<T>();
            IntPtr pointer = IntPtr.Zero;
            bool continue_ = true;
            int size = Marshal.SizeOf(typeof(T)) % 8;
            while( continue_ )
            {
                if (size == 0)
                {
                    object gap = new object();
                }
                candidates.AddLast(new T());
                GCHandle handle = GCHandle.Alloc(candidates.Last.Value, GCHandleType.Pinned);
                pointer = handle.AddrOfPinnedObject();
                continue_ = (pointer.ToInt64() % 8) != 0 || (pointer.ToInt64() % 64) == 24;
                handle.Free();
                if (!continue_)
                    return candidates.Last.Value;
            }
            return default(T);
        }
    }
    class Program
    {
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class Variable
        {
            public double Value;
        }
        static void Main()
        {
            const int COUNT = 10000000;
            
            while (true)
            {
                
                var x = AlignedNew.New<Variable>();
                
                for (int inner = 0; inner < 5; ++inner)
                {
                    var stopwatch = Stopwatch.StartNew();
                    var total = 0.0;
                    for (int i = 1; i <= COUNT; ++i)
                    {
                        x.Value = i;
                        total += x.Value;
                    }
                    if (Math.Abs(total - 50000005000000.0) > 1)
                        throw new ApplicationException(total.ToString());
                    Console.Write("{0}, ", stopwatch.ElapsedMilliseconds);
                }
                Console.WriteLine();
            }
        }
    }
