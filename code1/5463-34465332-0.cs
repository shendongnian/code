    namespace HelloWorld
    {
        using AppFunc = Func<IDictionary<DateTime, string>, List<string>>;
        public class Startup
        {
            public static AppFunc OrderEvents() 
            {
                AppFunc appFunc = (IDictionary<DateTime, string> events) =>
                {
                    if ((events != null) && (events.Count > 0))
                    {
                        List<string> result = events.OrderBy(ev => ev.Key)
                            .Select(ev => ev.Value)
                            .ToList();
                        return result;
                    }
                    throw new ArgumentException("Event dictionary is null or empty.");
                };
                return appFunc;
            }
        }
    }
