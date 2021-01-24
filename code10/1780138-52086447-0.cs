    class Program
    {
    
        static void Main(string[] args)
        {
            var foo = new Testclass();
            foo.test1();
    
            Display(foo);
            foo.call_test1();
            Display(foo);
            foo.call_test2();
            Display(foo);
            foo.call_test3();
            Display(foo);
            foo.call_test4();
            Display(foo);
        }
    
        private static void Display(Testclass foo)
        {
            foreach (var item in foo.test_dict)
            {
                Console.WriteLine(item.Value + item.Key);
            }
    
            Console.WriteLine();
        }
    }
    
    public partial class Testclass
    {
        public IDictionary<string, string> test_dict = new Dictionary<string, string>();
        private String ping_msg;
    
        public void test1()
        {
            test_dict = Develop.AddPing(ping_msg);
        }
    
        // chnages only NET_MSG value, other test_dict fields stay untouched!!!
        public void call_test1()
        {
            test_dict["NET_MSG"] = "Putting new message";
        }
    
        // chnages only NET_MSG value, other test_dict fields stay untouched!!!
        public void call_test2()
        {
            test_dict["NET_MSG"] = "Putting new message 2";
        }
    
        // chnages only NET_MSG value, other test_dict fields stay untouched!!!
        public void call_test3()
        {
            test_dict["NET_MSG"] = "Putting new message3";
        }
    
        // here you can change all the fields 
        public void call_test4()
        {
            test_dict["NET_MSG"] = "new net_msg value";
            test_dict["IP"] = "new ip value";
            test_dict["HOST"] = "new host value";
        }
    }
    
    public static class Develop
    {
    
        public static string get_IP()
        {
            return "blah";
        }
    
        public static string get_host()
        {
            return "blah2";
        }
    
        public static IDictionary<string, string> AddPing(String message)
        {
            return new Dictionary<string, string>()
            {
                {"NET_MSG", message},
                {"IP", get_IP()},
                {"HOST", get_host()}
            };
        }
    
    }
