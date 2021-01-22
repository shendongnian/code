    /// <summary>
    /// Provides extension methods for the <see cref="IDisposable"/> interface.
    /// </summary>
    public static class DisposableExtensions
    {
        /// <summary>
        /// Executes the specified action delegate using the disposable resource,
        /// then disposes of the said resource by calling its <see cref="IDisposable.Dispose()"/> method.
        /// </summary>
        /// <typeparam name="TDisposable">The type of the disposable resource to use.</typeparam>
        /// <param name="disposable">The disposable resource to use.</param>
        /// <param name="strategy">
        /// The strategy for propagating or swallowing exceptions thrown by the <see cref="IDisposable.Dispose"/> method.
        /// </param>
        /// <param name="action">The action delegate to execute using the disposable resource.</param>
        public static void Using<TDisposable>(this TDisposable disposable, DisposeExceptionStrategy strategy, Action<TDisposable> action)
            where TDisposable : IDisposable
        {
            ArgumentValidate.NotNull(disposable, nameof(disposable));
            ArgumentValidate.NotNull(action, nameof(action));
            ArgumentValidate.IsEnumDefined(strategy, nameof(strategy));
            disposable.Using(strategy, disposableInner =>
            {
                action(disposableInner);
                return true;   // dummy return value
            });
        }
        /// <summary>
        /// Executes the specified function delegate using the disposable resource,
        /// then disposes of the said resource by calling its <see cref="IDisposable.Dispose()"/> method.
        /// </summary>
        /// <typeparam name="TDisposable">The type of the disposable resource to use.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate.</typeparam>
        /// <param name="disposable">The disposable resource to use.</param>
        /// <param name="strategy">
        /// The strategy for propagating or swallowing exceptions thrown by the <see cref="IDisposable.Dispose"/> method.
        /// </param>
        /// <param name="func">The function delegate to execute using the disposable resource.</param>
        /// <returns>The return value of the function delegate.</returns>
        public static TResult Using<TDisposable, TResult>(this TDisposable disposable, DisposeExceptionStrategy strategy, Func<TDisposable, TResult> func)
            where TDisposable : IDisposable
        {
            ArgumentValidate.NotNull(disposable, nameof(disposable));
            ArgumentValidate.NotNull(func, nameof(func));
            ArgumentValidate.IsEnumDefined(strategy, nameof(strategy));
    #pragma warning disable 1998
            var dummyTask = disposable.UsingAsync(strategy, async (disposableInner) => func(disposableInner));
    #pragma warning restore 1998
            return dummyTask.GetAwaiter().GetResult();
        }
        /// <summary>
        /// Executes the specified asynchronous delegate using the disposable resource,
        /// then disposes of the said resource by calling its <see cref="IDisposable.Dispose()"/> method.
        /// </summary>
        /// <typeparam name="TDisposable">The type of the disposable resource to use.</typeparam>
        /// <param name="disposable">The disposable resource to use.</param>
        /// <param name="strategy">
        /// The strategy for propagating or swallowing exceptions thrown by the <see cref="IDisposable.Dispose"/> method.
        /// </param>
        /// <param name="asyncFunc">The asynchronous delegate to execute using the disposable resource.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static Task UsingAsync<TDisposable>(this TDisposable disposable, DisposeExceptionStrategy strategy, Func<TDisposable, Task> asyncFunc)
            where TDisposable : IDisposable
        {
            ArgumentValidate.NotNull(disposable, nameof(disposable));
            ArgumentValidate.NotNull(asyncFunc, nameof(asyncFunc));
            ArgumentValidate.IsEnumDefined(strategy, nameof(strategy));
            
            return disposable.UsingAsync(strategy, async (disposableInner) =>
            {
                await asyncFunc(disposableInner);
                return true;   // dummy return value
            });
        }
        /// <summary>
        /// Executes the specified asynchronous function delegate using the disposable resource,
        /// then disposes of the said resource by calling its <see cref="IDisposable.Dispose()"/> method.
        /// </summary>
        /// <typeparam name="TDisposable">The type of the disposable resource to use.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the asynchronous function delegate.</typeparam>
        /// <param name="disposable">The disposable resource to use.</param>
        /// <param name="strategy">
        /// The strategy for propagating or swallowing exceptions thrown by the <see cref="IDisposable.Dispose"/> method.
        /// </param>
        /// <param name="asyncFunc">The asynchronous function delegate to execute using the disposable resource.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains the return value of the asynchronous function delegate.
        /// </returns>
        public static async Task<TResult> UsingAsync<TDisposable, TResult>(this TDisposable disposable, DisposeExceptionStrategy strategy, Func<TDisposable, Task<TResult>> asyncFunc)
            where TDisposable : IDisposable
        {
            ArgumentValidate.NotNull(disposable, nameof(disposable));
            ArgumentValidate.NotNull(asyncFunc, nameof(asyncFunc));
            ArgumentValidate.IsEnumDefined(strategy, nameof(strategy));
            Exception mainException = null;
            try
            {
                return await asyncFunc(disposable);
            }
            catch (Exception exception)
            {
                mainException = exception;
                throw;
            }
            finally
            {
                try
                {
                    disposable.Dispose();
                }
                catch (Exception disposeException)
                {
                    switch (strategy)
                    {
                        case DisposeExceptionStrategy.Propagate:
                            throw;
                        case DisposeExceptionStrategy.Swallow:
                            break;   // swallow exception
                        case DisposeExceptionStrategy.Subjugate:
                            if (mainException == null)
                                throw;
                            break;    // otherwise swallow exception
                            
                        case DisposeExceptionStrategy.AggregateMultiple:
                            if (mainException != null)
                                throw new AggregateException(mainException, disposeException);
                            throw;
                        case DisposeExceptionStrategy.AggregateAlways:
                            if (mainException != null)
                                throw new AggregateException(mainException, disposeException);
                            throw new AggregateException(disposeException);
                    }
                }
                if (mainException != null && strategy == DisposeExceptionStrategy.AggregateAlways)
                    throw new AggregateException(mainException);
            }
        }
    }
