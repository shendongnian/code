    public class Snow : IWeather {...}
    public class Rain: IWeather {...}
    public class Bar : IFoo {
        IWeather  foo<T>() T : IWeather { 
            if (typeof(T)==typeof(Rain))
               return new Rain();
            if (typeof(T)==typeof(Snow))
               return new Snow();
            Throw new ArgumentException("Not implemented for " + typeof(T).Name);
        }
    }
