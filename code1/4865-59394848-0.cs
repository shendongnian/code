    public enum Test
        {
            Test1 = 1,
            Test2 = 2,
            Test3 = 3
        }
        class Program
        {
            static void Main(string[] args)
            {
                
                var items = Enum.GetValues(typeof(Test));
    
                foreach (var item in items)
                {
                    //Gives you the names
                    Console.WriteLine(item);
                }
                    
    
                foreach(var item in (Test[])items)
                {
                    // Gives you the numbers
                    Console.WriteLine((int)item);
                }
            }
        }
