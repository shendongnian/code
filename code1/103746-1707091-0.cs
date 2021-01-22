    public static class InstanceMap
    {
        private static readonly Dictionary<Type,object> instances = 
            new Dictionary<Type,object>();
        public static void AddInstance(object instance)
        {
            instances[instance.GetType()] = instance;
        }
        
        public static T GetInstance<T>() { return (T) instances[typeof(T)]; }  
    }
    public interface INonCompoundedInterestRate
    {
        INonCompoundedInterestRate ImpliedRate(double factor,
            double time,
            DayCounter dayCounter);
    }
    public class MyNonCompoundedInterestRate: INonCompoundedInterestRate
    {
        public INonCompoundedInterestRate ImpliedRate(double factor,
            double time,
            DayCounter dayCounter) { /* do smth*/ }
        static MyNonCompoundedInterestRate()
        {
            InstanceMap.AddInstance(new MyNonCompoundedInterestRate());
        } 
    } 
    public abstract class InterestRate {
        public static T ImpliedRate<T>(
            double factor,
            double time,
            DayCounter dayCounter
        ) where T : INonCompoundedInterestRate 
        {
            return InstanceMap.GetInstance<T>().
                ImpliedRate(factor, time, dayCounter);
        }
        // ...
    }
