    public static class Consumer
        {
    
            public static async Task<T> Go<T>()
            {
                var someLibrary = new SomeLibrary();
                return await someLibrary.SomeMethod(Async<T>);
            }
    
            public static async Task<T> Async<T>()
            {
                return await Task.FromResult(default(T));
            }
        }
    
    public class SomeLibrary
        {
            public async Task<T> SomeMethod<T>(Func<Task<T>> func)
            {
                return await func.Invoke();
            }
        }
