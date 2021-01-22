     class Program
        {
            static void Main(string[] args)
            {
                int enumlen = Enum.GetNames(typeof(myenum)).Length;
                Console.Write(enumlen);
                Console.Read();
            }
            public enum myenum
            {
                value1,
                value2
            }
        }
