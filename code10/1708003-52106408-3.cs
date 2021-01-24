    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
                await GetAllAsync().ForEachAsync((x) => Console.WriteLine(x)));
            Thread.Sleep(4000);
        }
        static IAsyncEnumerable<string> GetAllAsync()
        {
            var something = new[] { 1, 2, 3 };
            return something.SelectAsync(async (x) => await GetAsync(x));
        }
        static async Task<string> GetAsync(int item)
        {
            await Task.Delay(1000); // heavy
            return "got " + item;
        }
    }
    static class AsyncEnumerableExtensions
    {
        public static IAsyncEnumerable<TResult> SelectAsync<T, TResult>(this IEnumerable<T> enumerable, Func<T, Task<TResult>> selector)
        {
            return AsyncEnumerable.CreateEnumerable(() =>
            {
                var enumerator = enumerable.GetEnumerator();
                var current = default(TResult);
                return AsyncEnumerable.CreateEnumerator(async c =>
                    {
                        var moveNext = enumerator.MoveNext();
                        current = moveNext
                            ? await selector(enumerator.Current).ConfigureAwait(false)
                            : default(TResult);
                        return moveNext;
                    },
                    () => current,
                    () => enumerator.Dispose());
            });
        }
    }
