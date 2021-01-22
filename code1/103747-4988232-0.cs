    public static class InterestRateFactories
    {
        static InterestRateFactories()
        {
            _factories = new List<IInterestRateFactory>();
            //  register default factories, although you can also register them elsewhere, like in your ioc setup
        }
        private static readonly List<IInterestRateFactory> _factories;
        public static void RegisterFactory(IInterestRateFactory factory)
        {
            _factories.Add(factory);
        }
        public static T ImpliedRate<T>(double factor, double time, DayCounter dayCounter)
            where T : NonCompoundedInterestRate
        {
            var factory = _factories.FirstOrDefault(x => x.CanCreate(typeof(T), false));
            if (factory == null)
            {
                throw new NotSupportedException("Cannot create a non-compounded implied interest rate of type " + typeof(T).Name);
            }
            return (T)factory.Create(factor, time, dayCounter);
        }
        public static T ImpliedRate<T>(double factor, double time, DayCounter dayCounter, Frequency frequency)
            where T : CompoundedInterestRate
        {
            var factory = _factories.FirstOrDefault(x => x.CanCreate(typeof(T), false));
            if (factory == null)
            {
                throw new NotSupportedException("Cannot create a compounded implied interest rate of type " + typeof(T).Name);
            }
            return (T)factory.Create(factor, time, dayCounter, frequency);
        }
    }
    public interface IInterestRateFactory
    {
        bool CanCreate(Type nonCompoundedInterestRateType, bool compounded);
        NonCompoundedInterestRate Create(double factor, double time, DayCounter dayCounter);
        CompoundInterestRate Create(double factor, double time, DayCounter dayCounter, Frequency frequency);
    }
