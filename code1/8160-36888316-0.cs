    public class MyClass
    {
        private readonly MyDependency _dependency;
        public MyClass(MyDependency dependency)
        {
            _dependency = dependency;
        }
        public int CalculateHardStuff()
        {
            var intermediate = StepOne(_dependency);
            return StepTwo(intermediate);
        }
        private static int StepOne(MyDependency dependency)
        {
            return dependency.GetFirst3Primes().Sum();
        }
        private static int StepTwo(int intermediate)
        {
            return (intermediate + 5)/4;
        }
    }
    public class MyDependency
    {
        public IEnumerable<int> GetFirst3Primes()
        {
            yield return 2;
            yield return 3;
            yield return 5;
        }
    }
