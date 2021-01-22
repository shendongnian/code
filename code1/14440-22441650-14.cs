    interface IItem { }    
    class FooItem : IItem { }
    class BarItem : IItem { }
    
    class Program
    {
        static void Main(string[] args)
        {
            var objects = new object[] { new FooItem(), new BarItem(), new Alpha() };
            for (int i = 0; i < objects.Length; i++)
            {
                ProcessItem((dynamic)objects[i], "test" + i, i);
                
                //ProcesItm((dynamic)objects[i], "test" + i, i); 
                //compiler error: The name 'ProcesItm' does not 
                //exist in the current context
                //ProcessItem((dynamic)objects[i], "test" + i); 
                //error: No overload for method 'ProcessItem' takes 2 arguments
            }
        }
        static string ProcessItem<T>(T item, string text, int number) 
            where T : IItem
        {
            Console.WriteLine("Generic ProcessItem<{0}>, text {1}, number:{2}",
                              typeof(T), text, number);
            return "OK";
        }    
        static void ProcessItem(BarItem item, string text, int number)
        {
            Console.WriteLine("ProcessItem with Bar, " + text + ", " + number);
        }
    }
