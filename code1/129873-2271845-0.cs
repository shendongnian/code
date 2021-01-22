    public class Arguments {
        public T Get<T>(string argumentName,T defaultValue) {
            // look up and return value or defaultValue if not found
        }
    }
    return new SomeObject(
        args.Get<string>("Name","NoName"),
        args.Get<int>("Index",1)
    );
