    static class TimingInterfaceVsDelegateCalls
    {
        static SquareFunction _mathFunctionClass;
        static IMathFunction _mathFunctionInterface;
        static Func<double, double> _calculate;
        static Func<double, double> _derivate;
        static TimingInterfaceVsDelegateCalls()
        {
            _mathFunctionClass = new SquareFunction();
            _mathFunctionInterface = _mathFunctionClass;
            _calculate = _mathFunctionInterface.Calculate;
            _derivate = _mathFunctionInterface.Derivate;
        }
        interface IMathFunction
        {
            double Calculate(double input);
            double Derivate(double input);
        }
        sealed class SquareFunction : IMathFunction
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
            const int N = 100000000;
            const double msToNs = 1e6 / N;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkEmpty(i);
            }
            stopWatch.Stop();
            Console.WriteLine($"Empty Work method: {stopWatch.ElapsedMilliseconds * msToNs:n3}");
            stopWatch.Restart();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkInterface(i);
            }
            stopWatch.Stop();
            Console.WriteLine($"Interface: {stopWatch.ElapsedMilliseconds * msToNs:n3}");
            stopWatch.Restart();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkDelegate(i);
            }
            stopWatch.Stop();
            Console.WriteLine($"Delegates: {stopWatch.ElapsedMilliseconds * msToNs:n3}");
            stopWatch.Restart();
            for (int i = 0; i < N; i++) {
                double result = SomeWorkClass(i);
            }
            stopWatch.Stop();
            Console.WriteLine($"Class: {stopWatch.ElapsedMilliseconds * msToNs:n3}");
        }
        private static double SomeWorkEmpty(int i)
        {
            return 0.0;
        }
        private static double SomeWorkInterface(int i)
        {
            double f = _mathFunctionInterface.Calculate(i);
            double dv = _mathFunctionInterface.Derivate(i);
            return f - (dv * 12.34534);
        }
        private static double SomeWorkDelegate(int i)
        {
            double f = _calculate(i);
            double dv = _derivate(i);
            return f - (dv * 12.34534);
        }
        private static double SomeWorkClass(int i)
        {
            double f = _mathFunctionClass.Calculate(i);
            double dv = _mathFunctionClass.Derivate(i);
            return f - (dv * 12.34534);
        }
    }
