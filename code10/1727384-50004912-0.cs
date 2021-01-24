    using System;
    using System.Threading.Tasks;
    
    class Test
    {
        static async Task FooAsync()
        {
            await Bar<int>();
            await Bar<string>();
            await Task.Delay(1000);
            await Bar<string>();        
        }
        
        static Task<T> Bar<T>() => Task.FromResult(default(T));
    }
