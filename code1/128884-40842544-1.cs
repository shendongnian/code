    using System;
    using System.Linq;
    using sw = System.Diagnostics.Stopwatch;
    class Program
    {
        static void Main()
        {
            int[] a = new int[] { 1, 2, 3 },  // try: a={1,2,2} b={2,2,3}
                  b = new int[] { 4, 2, 3 }, c = new int[4];
            sw sw = sw.StartNew();
            for (int i = 5000000; i > 0; i--) { dssd1(a, b, c); dssd1(b, a, c); }
            Console.Write(sw.ElapsedMilliseconds);
            Console.Read();
        }
    
        static void dssd0(int[] a, int[] b, int[] c)               // 6710 ms.
        {
            int[] s = a.Intersect(b).ToArray();        // same
            int[] d = a.Union(b).Except(s).ToArray();  // diff
            c[0] = d[0]; c[1] = s[0]; c[2] = s[1]; c[3] = d[1];
        }
    
        static void dssd1(int[] a, int[] b, int[] c)               //   61 ms.
        {
            if (a[0] != b[0] && a[0] != b[1] && a[0] != b[2])
            { c[0] = a[0]; c[1] = a[1]; c[2] = a[2]; goto L0; }
            if (a[1] != b[0] && a[1] != b[1] && a[1] != b[2])
            { c[0] = a[1]; c[1] = a[0]; c[2] = a[2]; goto L0; }
            c[0] = a[2]; c[1] = a[0]; c[2] = a[1];
        L0: if (b[0] != c[1] && b[0] != c[2]) { c[3] = b[0]; return; }
            if (b[1] != c[1] && b[1] != c[2]) { c[3] = b[1]; return; }
            c[3] = b[2];
        }
    }
