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
        /// <param name="action">The action to execute using the disposable resource.</param>
        /// <param name="strategy">
        /// The strategy for propagating or swallowing exceptions thrown by the <see cref="IDisposable.Dispose"/> method.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="disposable"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
        public static void Using<TDisposable>(this TDisposable disposable, Action<TDisposable> action, DisposeExceptionStrategy strategy)
            where TDisposable : IDisposable
        {
            ArgumentValidate.NotNull(disposable, nameof(disposable));
            ArgumentValidate.NotNull(action, nameof(action));
            ArgumentValidate.IsEnumDefined(strategy, nameof(strategy));
            Exception mainException = null;
            try
            {
                action(disposable);
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
