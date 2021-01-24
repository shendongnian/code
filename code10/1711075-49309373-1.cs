    using System;
    using System.Diagnostics;
    using System.Numerics;
    class Program
    {
        static void Main(string[] args)
        {
            double alpha = 0.5;
            double[] x = new double[16 * 1024], y = new double[x.Length];
            var rand = new Random(12345);
            for (int i = 0; i < x.Length; i++)
                x[i] = rand.NextDouble();
            RunAll(alpha, x, y, 1, false);
            RunAll(alpha, x, y, 10000, true);
        }
        private static void RunAll(double alpha, double[] x, double[] y, int loop, bool log)
        {
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            var watch = Stopwatch.StartNew();
            for(int i = 0; i < loop; i++)
            {
                daxpy_naive(alpha, x, y);
            }
            watch.Stop();
            if (log) Console.WriteLine($"{nameof(daxpy_naive)} x{loop}: {watch.ElapsedMilliseconds}ms");
            watch = Stopwatch.StartNew();
            for (int i = 0; i < loop; i++)
            {
                daxpy_arr_vector(alpha, x, y);
            }
            watch.Stop();
            if (log) Console.WriteLine($"{nameof(daxpy_arr_vector)} x{loop}: {watch.ElapsedMilliseconds}ms");
            watch = Stopwatch.StartNew();
            for (int i = 0; i < loop; i++)
            {
                daxpy_span(alpha, x, y);
            }
            watch.Stop();
            if (log) Console.WriteLine($"{nameof(daxpy_span)} x{loop}: {watch.ElapsedMilliseconds}ms");
            watch = Stopwatch.StartNew();
            for (int i = 0; i < loop; i++)
            {
                daxpy_vector(alpha, x, y);
            }
            watch.Stop();
            if (log) Console.WriteLine($"{nameof(daxpy_vector)} x{loop}: {watch.ElapsedMilliseconds}ms");
            watch = Stopwatch.StartNew();
            for (int i = 0; i < loop; i++)
            {
                daxpy_vector_no_slice(alpha, x, y);
            }
            watch.Stop();
            if (log) Console.WriteLine($"{nameof(daxpy_vector_no_slice)} x{loop}: {watch.ElapsedMilliseconds}ms");
        }
        public static void daxpy_naive(double alpha, double[] x, double[] y)
        {
            for (var i = 0; i < x.Length; ++i)
                y[i] = y[i] + x[i] * alpha;
        }
        public static void daxpy_arr_vector(double alpha, double[] x, double[] y)
        {
            var i = 0;
            if (Vector.IsHardwareAccelerated)
            {
                var length = x.Length + 1 - Vector<double>.Count;
                for (; i < length; i += Vector<double>.Count)
                {
                    var valpha = new Vector<double>(alpha);
                    var vx = new Vector<double>(x, i);
                    var vy = new Vector<double>(y, i);
                    (vy + vx * valpha).CopyTo(y, i);
                }
            }
            for (; i < x.Length; ++i)
                y[i] = y[i] + x[i] * alpha;
        }
        public static void daxpy_span(double alpha, Span<double> x, Span<double> y)
        {
            for (var i = 0; i < x.Length; ++i)
                y[i] += x[i] * alpha;
        }
        public static void daxpy_vector(double alpha, Span<double> x, Span<double> y)
        {
            if (Vector.IsHardwareAccelerated)
            {
                var vx = x.NonPortableCast<double, Vector<double>>();
                var vy = y.NonPortableCast<double, Vector<double>>();
                var valpha = new Vector<double>(alpha);
                for (var i = 0; i < vx.Length; ++i)
                    vy[i] += vx[i] * valpha;
                x = x.Slice(Vector<double>.Count * vx.Length);
                y = y.Slice(Vector<double>.Count * vy.Length);
            }
            for (var i = 0; i < x.Length; ++i)
                y[i] += x[i] * alpha;
        }
        public static void daxpy_vector_no_slice(double alpha, Span<double> x, Span<double> y)
        {
            int i = 0;
            if (Vector.IsHardwareAccelerated)
            {
                var vx = x.NonPortableCast<double, Vector<double>>();
                var vy = y.NonPortableCast<double, Vector<double>>();
                var valpha = new Vector<double>(alpha);
                for (i = 0; i < vx.Length; ++i)
                    vy[i] += vx[i] * valpha;
                i = Vector<double>.Count * vx.Length;
            }
            for (; i < x.Length; ++i)
                y[i] += x[i] * alpha;
        }
    }
