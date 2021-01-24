    /// <summary>
    /// Provides support for asynchronous lazy initialization.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LazyAsync<T> : Lazy<Task<T>> {
        /// <summary>
        ///  Initializes a new instance of the LazyAsync`1 class. When lazy initialization
        ///  occurs, the specified initialization function is used.
        /// </summary>
        /// <param name="valueFactory">The delegate that is invoked to produce the lazily initialized Task when it is needed.</param>
        public LazyAsync(Func<Task<T>> valueFactory) :
            base(() => Task.Run(valueFactory)) { }
    }
