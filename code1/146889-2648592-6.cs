    class Program
    {
        static AppDomain otherDomain;
        static void Main(string[] args)
        {
            otherDomain = AppDomain.CreateDomain("other domain");
            var otherType = typeof(OtherProgram);
            var obj = otherDomain.CreateInstanceAndUnwrap(
                                     otherType.Assembly.FullName,
                                     otherType.FullName) as OtherProgram;
            args = new[] { "hello", "world" };
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            obj.Main(args);
        }
    }
    public class OtherProgram : MarshalByRefObject
    {
        public void Main(string[] args)
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            foreach (var item in args)
                Console.WriteLine(item);
        }
    }
