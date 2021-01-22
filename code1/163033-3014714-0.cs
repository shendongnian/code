    using System;
    
    namespace RandomEnum
    {
        class Program
        {
            private enum TestEnum
            {
                One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten
            };
    
            static void Main(string[] args)
            {
                string[] names = Enum.GetNames(typeof (TestEnum));
    
                Random random = new Random();
    
                int randomEnum = random.Next(names.Length);
    
                var ret = Enum.Parse(typeof (TestEnum), names[randomEnum]);
    
                Console.WriteLine(ret.ToString());
            }
        }
    }
