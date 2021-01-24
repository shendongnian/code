    // CODE FOR EDUCATIONAL PURPOSES ONLY. DON'T USE IN PRODUCTION!
    using System;
       
    public class FuncWrapper
    {
        private readonly Func<string> func;
        
        public FuncWrapper(Func<string> func) =>
            this.func = func;
        
        public override string ToString() => func();
    }
    
    class Test
    {
        static void Main()
        {
            int i = 1;
            // Capture i in a delegate; each time the delegate
            // is executed, you'll get a different value. Each
            // time ToString is called, the delegate will be called
            var wrapper = new FuncWrapper(() => i.ToString());
            
            FormattableString dynamicString = $"i = {wrapper}";
            while (i < 10)
            {
                Console.WriteLine(dynamicString);
                i++;
            }
        }
    }
