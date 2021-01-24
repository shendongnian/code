    static class TimingInterfaceVsDelegateCalls
    {
        const int N = 100000000;
        const double msToNs = 1e6 / N;
        static SquareFunctionSealed _mathFunctionClassSealed;
        static SquareFunction _mathFunctionClass;
        static IMathFunction _mathFunctionInterface;
        static Func<double, double> _calculate;
        static Func<double, double> _derivate;
        static TimingInterfaceVsDelegateCalls()
        {
            _mathFunctionClass = new SquareFunction();
            _mathFunctionClassSealed = new SquareFunctionSealed();
            _mathFunctionInterface = _mathFunctionClassSealed;
            _calculate = _mathFunctionInterface.Calculate;
            _derivate = _mathFunctionInterface.Derivate;
        }
        interface IMathFunction
        {
            double Calculate(double input);
            double Derivate(double input);
        }
        sealed class SquareFunctionSealed : IMathFunction
        {
            public double Calculate(double input)
            {
                return input * input;
            }
            public double Derivate(double input)
            {
                return 2 * input;
            }
        }
        class SquareFunction : IMathFunction
        {
            public double Calculate(double input)
            {
                return input * input;
            }
            public double Derivate(double input)
            {
                return 2 * input;
            }
        }
        public static void Test()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkEmpty(i);
            }
            stopWatch.Stop();
            double emptyTime = stopWatch.ElapsedMilliseconds * msToNs;
            Console.WriteLine($"Empty Work method: {emptyTime:n2}");
            stopWatch.Restart();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkInterface(i);
            }
            stopWatch.Stop();
            PrintResult("Interface", stopWatch.ElapsedMilliseconds, emptyTime);
            stopWatch.Restart();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkDelegate(i);
            }
            stopWatch.Stop();
            PrintResult("Delegates", stopWatch.ElapsedMilliseconds, emptyTime);
            stopWatch.Restart();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkClassSealed(i);
            }
            stopWatch.Stop();
            PrintResult("Sealed Class", stopWatch.ElapsedMilliseconds, emptyTime);
            stopWatch.Restart();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkClass(i);
            }
            stopWatch.Stop();
            PrintResult("Class", stopWatch.ElapsedMilliseconds, emptyTime);
        }
        private static void PrintResult(string text, long elapsed, double emptyTime)
        {
            Console.WriteLine($"{text}: {elapsed * msToNs:n2} ({elapsed * msToNs - emptyTime:n2})");
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static double SomeWorkEmpty(int i)
        {
            return 0.0;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static double SomeWorkInterface(int i)
        {
            double f = _mathFunctionInterface.Calculate(i);
            double dv = _mathFunctionInterface.Derivate(i);
            return f - (dv * 12.34534);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static double SomeWorkDelegate(int i)
        {
            double f = _calculate(i);
            double dv = _derivate(i);
            return f - (dv * 12.34534);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static double SomeWorkClassSealed(int i)
        {
            double f = _mathFunctionClassSealed.Calculate(i);
            double dv = _mathFunctionClassSealed.Derivate(i);
            return f - (dv * 12.34534);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static double SomeWorkClass(int i)
        {
            double f = _mathFunctionClass.Calculate(i);
            double dv = _mathFunctionClass.Derivate(i);
            return f - (dv * 12.34534);
        }
    }
