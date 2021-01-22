    using System;
    using System.Linq;
    using System.Reflection;
    public interface ILogger<T> { /*... */}
    
    public class IntLogger : ILogger<int> { }
    
    public class StringLogger : ILogger<string> { }
    
    public class DateTimeLogger : ILogger<DateTime> { }
    
    public class LoggerFactory
    {
        public static ILogger<T> Create<T>()
        {
            // look within the current assembly for matching implementation
            // this could be extended to search across all loaded assemblies
            // relatively easily - at the expense of performance
            // also, you probably want to cache these results...
            var loggerType = Assembly.GetExecutingAssembly()
                         .GetTypes()
                         // find implementations of ILogger<T> that match on T
                         .Where(t => typeof(ILogger<T>).IsAssignableFrom(t))
                         // throw an exception if more than one handler found,
                         // could be revised to be more friendly, or make a choice
                         // amongst multiple available options...
                         .Single(); 
    
            var ctor = loggerType.GetConstructor( Type.EmptyTypes );
            if (ctor != null)
                return ctor.Invoke( null ) as ILogger<T>;
            
            // couldn't find an implementation
            throw new ArgumentException(
              "No mplementation of ILogger<{0}>" + typeof( T ) );
        }
    }
    
    // some very basic tests to validate the approach...
    public static class TypeDispatch
    {
        public static void Main( string[] args )
        {
            var intLogger      = LoggerFactory.Create<int>();
            var stringLogger   = LoggerFactory.Create<string>();
            var dateTimeLogger = LoggerFactory.Create<DateTime>();
            // no logger for this type; throws exception...
            var notFoundLogger = LoggerFactory.Create<double>(); 
        }
    }
