    using System;
    using System.IO;
    // WARNING!
    // This code includes possible memory access errors with unfixed/unpinned pointers!
    namespace DangerousNamespace
    {
        public class DangerousClass
        {
            public static void Main()
            {
                unsafe
                {
                    double[][] array = new double[3][];
                    array[0] = new double[] { 1.25, 2.28, 3, 4 };
                    array[1] = new double[] { 5, 6.24, 7.42, 8 };
                    array[2] = new double[] { 9, 10.15, 11, 12.14 };
                    fixed (double* junk = &array[0][0])
                    {
                        double*[] arrayofptr = new double*[array.Length];
                        for (int i = 0; i < array.Length; i++)
                            fixed (double* ptr = &array[i][0])
                            {
                                arrayofptr[i] = ptr;
                            }
                        for (int i = 0; i < 10000000; ++i)
                        {
                            Object z = new Object();
                        }
                        GC.Collect();
                        fixed (double** ptrptr = &arrayofptr[0])
                        {
                            for (int i = 0; i < 1000000; ++i)
                            {
                                using (MemoryStream z = new MemoryStream(200))
                                {
                                    z.Write(new byte[] { 1, 2, 3 }, 1, 2);
                                }
                            }
                            GC.Collect();
                            // should print 1.25
                            Console.WriteLine(*(double*)(*(double**)ptrptr));
                        }
                    }
                }
            }
        }
    }
