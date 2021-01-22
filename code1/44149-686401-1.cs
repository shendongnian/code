    public static void RunAsync<T>(
        Func<AsyncCallback, object, IAsyncResult> begin,
        Func<IAsyncResult, T> end,
        Action<Func<T>> callback) {
        begin(ar => {
            T result;
            try {
                result = end(ar); // ensure end called
                callback(() => result);
            } catch (Exception ex) {
                callback(() => { throw ex; });
            }
        }, null);
    }
