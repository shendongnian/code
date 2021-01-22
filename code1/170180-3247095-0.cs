    namespace  silly
    {
        public static class Program
        {
            //declared volatile to make sure the object is in a consistent state
            //between thread usages -- For thread safety.
            public static volatile Object_w_Methods _method_provider = null;
            static void Main(string[] args)
            {
                //right now, _method_provider is null.
                System.Threading.Thread _creator_thread = new System.Threading.Thread(
                    new System.Threading.ThreadStart(Create_Object));
                _creator_thread.Name = "Thread for creation of object";
                _creator_thread.Start();
                //here I can do other work while _method_provider is created.
                System.Threading.Thread.Sleep(256);
                _creator_thread.Join();
                //by now, the other thread has created the _method_provider
                //so we can use his methods in this thread, and any other thread!
                System.Console.WriteLine("I got the name!!  It is: `" + 
                    _method_provider.Get_Name(1) + "'");
                System.Console.WriteLine("Press any key to exit...");
                System.Console.ReadKey(true);
            }
            static void Create_Object()
            {
                System.Threading.Thread.Sleep(512);
                _method_provider = new Object_w_Methods();
            }
        }
        public class Object_w_Methods
        {
            //Synchronize because it will probably be used by multiple threads,
            //even though the current implementation is thread safe.
            [System.Runtime.CompilerServices.MethodImpl( 
                System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
            public string Get_Name(int id)
            {
                switch (id)
                {
                    case 1:
                        return "one is the name";
                    case 2:
                        return "two is the one you want";
                    default:
                        return "supply the correct ID.";
    }}}}
