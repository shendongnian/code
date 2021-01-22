    /// <summary>
    /// Identifies the strategy for propagating or swallowing exceptions thrown by the <see cref="IDisposable.Dispose"/> method
    /// of an <see cref="IDisposable"/> instance, in conjunction with exceptions thrown by the main logic.
    /// </summary>
    /// <remarks>
    /// This enumeration is intended to be used from the <see cref="DisposableExtensions.Using"/> extension method.
    /// </remarks>
    public enum DisposeExceptionStrategy
    {
        /// <summary>
        /// Propagates any exceptions thrown by the <see cref="IDisposable.Dispose"/> method.
        /// If another exception was already thrown by the main logic, it will be hidden and lost.
        /// This behaviour is consistent with the standard semantics of the <see langword="using"/> keyword.
        /// </summary>
        /// <remarks>
        /// <para>
        /// According to Section 8.10 of the C# Language Specification (version 5.0):
        /// </para>
        /// <blockquote>
        /// If an exception is thrown during execution of a <see langword="finally"/> block,
        /// and is not caught within the same <see langword="finally"/> block, 
        /// the exception is propagated to the next enclosing <see langword="try"/> statement. 
        /// If another exception was in the process of being propagated, that exception is lost. 
        /// </blockquote>
        /// </remarks>
        Propagate,
        /// <summary>
        /// Always swallows any exceptions thrown by the <see cref="IDisposable.Dispose"/> method,
        /// regardless of whether another exception was already thrown by the main logic or not.
        /// </summary>
        /// <remarks>
        /// This strategy is presented by Marc Gravell in
        /// <see href="http://blog.marcgravell.com/2008/11/dontdontuse-using.html">don't(don't(use using))</see>.
        /// </remarks>
        Swallow,
        /// <summary>
        /// Swallows any exceptions thrown by the <see cref="IDisposable.Dispose"/> method
        /// if and only if another exception was already thrown by the main logic.
        /// </summary>
        /// <remarks>
        /// This strategy is suggested in the first example of the Stack Overflow question
        /// <see href="http://stackoverflow.com/q/1654487/1149773">Swallowing exception thrown in catch/finally block</see>.
        /// </remarks>
        Subjugate,
        /// <summary>
        /// Wraps multiple exceptions, when thrown by both the main logic and the <see cref="IDisposable.Dispose"/> method,
        /// into an <see cref="AggregateException"/>. If just one exception occurred (in either of the two),
        /// the original exception is propagated.
        /// </summary>
        /// <remarks>
        /// This strategy is implemented by Daniel Chambers in
        /// <see href="http://www.digitallycreated.net/Blog/51/c%23-using-blocks-can-swallow-exceptions">C# Using Blocks can Swallow Exceptions</see>
        /// </remarks>
        AggregateMultiple,
        /// <summary>
        /// Always wraps any exceptions thrown by the main logic and/or the <see cref="IDisposable.Dispose"/> method
        /// into an <see cref="AggregateException"/>, even if just one exception occurred.
        /// </summary>
        /// <remarks>
        /// This strategy is similar to behaviour of the <see cref="Task.Wait()"/> method of the <see cref="Task"/> class 
        /// and the <see cref="Task{TResult}.Result"/> property of the <see cref="Task{TResult}"/> class:
        /// <blockquote>
        /// Even if only one exception is thrown, it is still wrapped in an <see cref="AggregateException"/> exception.
        /// </blockquote>
        /// </remarks>
        AggregateAlways,
    }
