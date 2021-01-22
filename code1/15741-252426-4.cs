    public static class AsynchronousQueryExecutor
    {
        public static void Call<T>(IEnumerable<T> query, Action<IEnumerable<T>> callback)
        {
            Func<IEnumerable<T>, IEnumerable<T>> func =
                new Func<IEnumerable<T>, IEnumerable<T>>(InnerEnumerate<T>);
            IAsyncResult ar = func.BeginInvoke(
                                query, 
                                new AsyncCallback(delegate(IAsyncResult arr)
                                {
                                    callback(((Func<IEnumerable<T>, IEnumerable<T>>)((AsyncResult)arr).AsyncDelegate).EndInvoke(arr));
                                }), 
                                null);
        }
        private static IEnumerable<T> InnerEnumerate<T>(IEnumerable<T> query)
        {
            //by doing this, we handle the deferred execution problem
            foreach (var item in query) 
            {
                yield return item;
            }
        }
    }
