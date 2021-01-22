    class Program
    {
        static void Main(string[] args)
        {
            var sampleElement = "Foo";
    
            Type listType = typeof(List<>).MakeGenericType(sampleElement.GetType());
            Type actionType = typeof(Action<>).MakeGenericType(sampleElement.GetType());
    
            var list = Activator.CreateInstance(listType);
            var action = Delegate.CreateDelegate(actionType, null, typeof(Program).GetMethod ("ForEach"));
    
            (list as List<string>).AddRange (new []{ "1", "2" });
    
            listType.GetMethod ("ForEach").Invoke (list, new object []{ action });
        }
    
        public static void ForEach(string item)
        {
            Console.WriteLine(item);
        }
    }
