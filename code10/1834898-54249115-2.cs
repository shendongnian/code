    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    
    namespace AsyncAwaitBestPractices.MVVM
    {
        /// <summary>
        /// An implmentation of IAsyncCommand. Allows Commands to safely be used asynchronously with Task.
        /// </summary>
        public sealed class AsyncCommand<T> : IAsyncCommand<T>
        {
            #region Constant Fields
            readonly Func<T, Task> _execute;
            readonly Func<object, bool> _canExecute;
            readonly Action<Exception> _onException;
            readonly bool _continueOnCapturedContext;
            readonly WeakEventManager _weakEventManager = new WeakEventManager();
            #endregion
    
            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="T:TaskExtensions.MVVM.AsyncCommand`1"/> class.
            /// </summary>
            /// <param name="execute">The Function executed when Execute or ExecuteAysnc is called. This does not check canExecute before executing and will execute even if canExecute is false</param>
            /// <param name="canExecute">The Function that verifies whether or not AsyncCommand should execute.</param>
            /// <param name="onException">If an exception is thrown in the Task, <c>onException</c> will execute. If onException is null, the exception will be re-thrown</param>
            /// <param name="continueOnCapturedContext">If set to <c>true</c> continue on captured context; this will ensure that the Synchronization Context returns to the calling thread. If set to <c>false</c> continue on a different context; this will allow the Synchronization Context to continue on a different thread</param>
            public AsyncCommand(Func<T, Task> execute,
                                Func<object, bool> canExecute = null,
                                Action<Exception> onException = null,
                                bool continueOnCapturedContext = true)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute), $"{nameof(execute)} cannot be null");
                _canExecute = canExecute ?? (_ => true);
                _onException = onException;
                _continueOnCapturedContext = continueOnCapturedContext;
            }
            #endregion
    
            #region Events
            /// <summary>
            /// Occurs when changes occur that affect whether or not the command should execute
            /// </summary>
            public event EventHandler CanExecuteChanged
            {
                add => _weakEventManager.AddEventHandler(value);
                remove => _weakEventManager.RemoveEventHandler(value);
            }
            #endregion
    
            #region Methods
            /// <summary>
            /// Determines whether the command can execute in its current state
            /// </summary>
            /// <returns><c>true</c>, if this command can be executed; otherwise, <c>false</c>.</returns>
            /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
            public bool CanExecute(object parameter) => _canExecute(parameter);
    
            /// <summary>
            /// Raises the CanExecuteChanged event.
            /// </summary>
            public void RaiseCanExecuteChanged() => _weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));
    
            /// <summary>
            /// Executes the Command as a Task
            /// </summary>
            /// <returns>The executed Task</returns>
            /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
            public Task ExecuteAsync(T parameter) => _execute(parameter);
    
            void ICommand.Execute(object parameter)
            {
                if (parameter is T validParameter)
                    ExecuteAsync(validParameter).SafeFireAndForget(_continueOnCapturedContext, _onException);
                else if (parameter is null && !typeof(T).IsValueType)
                    ExecuteAsync((T)parameter).SafeFireAndForget(_continueOnCapturedContext, _onException);
                else
                    throw new InvalidCommandParameterException(typeof(T), parameter.GetType());
            }
            #endregion
        }
    
        /// <summary>
        /// An implmentation of IAsyncCommand. Allows Commands to safely be used asynchronously with Task.
        /// </summary>
        public sealed class AsyncCommand : IAsyncCommand
        {
            #region Constant Fields
            readonly Func<Task> _execute;
            readonly Func<object, bool> _canExecute;
            readonly Action<Exception> _onException;
            readonly bool _continueOnCapturedContext;
            readonly WeakEventManager _weakEventManager = new WeakEventManager();
            #endregion
    
            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="T:TaskExtensions.MVVM.AsyncCommand`1"/> class.
            /// </summary>
            /// <param name="execute">The Function executed when Execute or ExecuteAysnc is called. This does not check canExecute before executing and will execute even if canExecute is false</param>
            /// <param name="canExecute">The Function that verifies whether or not AsyncCommand should execute.</param>
            /// <param name="onException">If an exception is thrown in the Task, <c>onException</c> will execute. If onException is null, the exception will be re-thrown</param>
            /// <param name="continueOnCapturedContext">If set to <c>true</c> continue on captured context; this will ensure that the Synchronization Context returns to the calling thread. If set to <c>false</c> continue on a different context; this will allow the Synchronization Context to continue on a different thread</param>
            public AsyncCommand(Func<Task> execute,
                                Func<object, bool> canExecute = null,
                                Action<Exception> onException = null,
                                bool continueOnCapturedContext = true)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute), $"{nameof(execute)} cannot be null");
                _canExecute = canExecute ?? (_ => true);
                _onException = onException;
                _continueOnCapturedContext = continueOnCapturedContext;
            }
            #endregion
    
            #region Events
            /// <summary>
            /// Occurs when changes occur that affect whether or not the command should execute
            /// </summary>
            public event EventHandler CanExecuteChanged
            {
                add => _weakEventManager.AddEventHandler(value);
                remove => _weakEventManager.RemoveEventHandler(value);
            }
            #endregion
    
            #region Methods
            /// <summary>
            /// Determines whether the command can execute in its current state
            /// </summary>
            /// <returns><c>true</c>, if this command can be executed; otherwise, <c>false</c>.</returns>
            /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
            public bool CanExecute(object parameter) => _canExecute(parameter);
    
            /// <summary>
            /// Raises the CanExecuteChanged event.
            /// </summary>
            public void RaiseCanExecuteChanged() => _weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));
    
            /// <summary>
            /// Executes the Command as a Task
            /// </summary>
            /// <returns>The executed Task</returns>
            public Task ExecuteAsync() => _execute();
    
            void ICommand.Execute(object parameter) => _execute().SafeFireAndForget(_continueOnCapturedContext, _onException);
            #endregion
        }
        /// <summary>
        /// Extension methods for System.Threading.Tasks.Task
        /// </summary>
        public static class TaskExtensions
        {
            /// <summary>
            /// Safely execute the Task without waiting for it to complete before moving to the next line of code; commonly known as "Fire And Forget". Inspired by John Thiriet's blog post, "Removing Async Void": https://johnthiriet.com/removing-async-void/.
            /// </summary>
            /// <param name="task">Task.</param>
            /// <param name="continueOnCapturedContext">If set to <c>true</c> continue on captured context; this will ensure that the Synchronization Context returns to the calling thread. If set to <c>false</c> continue on a different context; this will allow the Synchronization Context to continue on a different thread</param>
            /// <param name="onException">If an exception is thrown in the Task, <c>onException</c> will execute. If onException is null, the exception will be re-thrown</param>
            #pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
            public static async void SafeFireAndForget(this System.Threading.Tasks.Task task, bool continueOnCapturedContext = true, System.Action<System.Exception> onException = null)
            #pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
            {
                try
                {
                    await task.ConfigureAwait(continueOnCapturedContext);
                }
                catch (System.Exception ex) when (onException != null)
                {
                    onException?.Invoke(ex);
                }
            }
        }
        /// <summary>
        /// Weak event manager that allows for garbage collection when the EventHandler is still subscribed
        /// </summary>
        public class WeakEventManager
        {
            readonly Dictionary<string, List<Subscription>> _eventHandlers = new Dictionary<string, List<Subscription>>();
            /// <summary>
            /// Adds the event handler
            /// </summary>
            /// <param name="handler">Handler</param>
            /// <param name="eventName">Event name</param>
            public void AddEventHandler(Delegate handler, [CallerMemberName] string eventName = "")
        {
                if (IsNullOrWhiteSpace(eventName))
                    throw new ArgumentNullException(nameof(eventName));
                if (handler is null)
                    throw new ArgumentNullException(nameof(handler));
                EventManagerService.AddEventHandler(eventName, handler.Target, handler.GetMethodInfo(), _eventHandlers);
            }
            /// <summary>
            /// Removes the event handler.
            /// </summary>
            /// <param name="handler">Handler</param>
            /// <param name="eventName">Event name</param>
            public void RemoveEventHandler(Delegate handler, [CallerMemberName] string eventName = "")
            {
                if (IsNullOrWhiteSpace(eventName))
                    throw new ArgumentNullException(nameof(eventName));
                if (handler is null)
                    throw new ArgumentNullException(nameof(handler));
                EventManagerService.RemoveEventHandler(eventName, handler.Target, handler.GetMethodInfo(), _eventHandlers);
            }
            /// <summary>
            /// Executes the event
            /// </summary>
            /// <param name="sender">Sender</param>
            /// <param name="eventArgs">Event arguments</param>
            /// <param name="eventName">Event name</param>
            public void HandleEvent(object sender, object eventArgs, string eventName) => EventManagerService.HandleEvent(eventName, sender, eventArgs, _eventHandlers);
        }
        /// <summary>
        /// An Async implmentation of ICommand
        /// </summary>
        public interface IAsyncCommand<T> : System.Windows.Input.ICommand
        {
            /// <summary>
            /// Executes the Command as a Task
            /// </summary>
            /// <returns>The executed Task</returns>
            /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
            System.Threading.Tasks.Task ExecuteAsync(T parameter);
        }
        /// <summary>
        /// An Async implmentation of ICommand
        /// </summary>
        public interface IAsyncCommand : System.Windows.Input.ICommand
        {
            /// <summary>
            /// Executes the Command as a Task
            /// </summary>
            /// <returns>The executed Task</returns>
            System.Threading.Tasks.Task ExecuteAsync();
        }
    }
