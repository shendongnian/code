        static void Main(string[] args)
        {
            // -----------------------------------------------
            // Pre .NET 4.5 or gcAllowVeryLargeObjects unset
            const int twoGig = 2147483591; // magic number from .NET
            var type = typeof(int);          // type to use
            var size = Marshal.SizeOf(type); // type size
            var num = twoGig / size;         // max element count
            var arr20 = Array.CreateInstance(type, num);
            var arr21 = new byte[num];
            // -----------------------------------------------
            // .NET 4.5 with x64 and gcAllowVeryLargeObjects set
            var arr451 = new byte[2147483591];
            var arr452 = Array.CreateInstance(typeof(int), 2146435071);
            var arr453 = new byte[2146435071]; // another magic number
            return;
        }
