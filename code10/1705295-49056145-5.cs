        static void Main()
        {
            var myKey = new MyKey { MyBusinessKey = "Ohai" };
            var dic = new Dictionary<MyKey, int>();
            dic.Add(myKey, 1);
            Console.WriteLine(dic[myKey]);
            myKey.MyBusinessKey = "Changing value";
            Console.WriteLine(dic[myKey]); // Key Not Found Exception.
        }
        public class MyKey
        {
            public string MyBusinessKey { get; set; }
            public override int GetHashCode()
            {
                return MyBusinessKey.GetHashCode();
            }
        }
