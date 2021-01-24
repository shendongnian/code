        // Return a logger with a specification on how to parse a stream from a body
        private static TypeLogger CreateLogger<T>()
        {
            return new TypeLogger<T>((ctx) => ControllerBase.ParseBody<T>(contextDto.Body));
        }
        // Create a list with paths and loggers of specified type
        private Dictionary<string, TypeLogger> loggers = new Dictionary<string, TypeLogger>
        {
            { "/path1", CreateLogger<CustomerPostDto>() },
            { "/path2", CreateLogger<CustomerPostDto>() },
        };
        
        // Abstract base logger class that allows you to log from a requestbody
        public abstract class TypeLogger
        {
            public abstract void Log(System.IO.Stream requestBody);
        }
        // An actual implementation to parse your dto using by using the parser previously specified
        public class TypeLogger<T> : TypeLogger
        {
            // Parser to use when getting entity
            public Func<System.IO.Stream, T> Parser { get; private set; }
            // Constructor that takes sa func which helps us parse
            public TypeLogger(Func<System.IO.Stream, T> parser) => Parser = parser;
            // The actual logging
            public override void Log(System.IO.Stream requestBody)
            {
                var dto = Parser(requestBody);
                //...
            }
        }
        
        // And usage
        if (loggers.Contains(path))
            loggers[path].Log(ctx.Response.Body);
