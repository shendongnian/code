    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace IndexerSample
    {
        class FailSoftArray 
        {
            int[] a; // reference to underlying array
            public int Length; // Length is public
            public bool ErrFlag; // indicates outcome of last operation
            // Construct array given its size.
            public FailSoftArray(int size)
            {
                a = new int[size];
                Length = size;
            }
            // This is the indexer for FailSoftArray.
            public int this[int index] 
            {
            // This is the get accessor.
                get
                {
                    if (ok(index))
                    {
                        ErrFlag = false;
                        return a[index];
                    }
                    else
                    {
                        ErrFlag = true;
                        return 0;
                    }
                }
                // This is the set accessor.
                set
                {
                    if (ok(index))
                    {
                        a[index] = value;
                        ErrFlag = false;
                    }
                    else ErrFlag = true;
                }
            }
            // Return true if index is within bounds.
            private bool ok(int index)
            {
                if (index >= 0 & index < Length) return true;
                return false;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                FailSoftArray fs = new FailSoftArray(5);
                int x;
                // Show quiet failures.
                Console.WriteLine("Fail quietly.");
                for (int i = 0; i < (fs.Length * 2); i++)
                    fs[i] = i * 10;
                for (int i = 0; i < (fs.Length * 2); i++)
                {
                    x = fs[i];
                    if (x != -1) Console.Write(x + " ");
                }
                Console.WriteLine();
                // Now, display failures.
                Console.WriteLine("\nFail with error reports.");
                for (int i = 0; i < (fs.Length * 2); i++)
                {
                    fs[i] = i * 10;
                    if (fs.ErrFlag)
                        Console.WriteLine("fs[" + i + "] out-of-bounds");
                }
                for (int i = 0; i < (fs.Length * 2); i++)
                {
                    x = fs[i];
                    if (!fs.ErrFlag) Console.Write(x + " ");
                    else
                        Console.WriteLine("fs[" + i + "] out-of-bounds");
                }
                Console.ReadLine();
            }
        }
    }
