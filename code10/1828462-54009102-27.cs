    using System;
    using System.Windows.Input;
    
    namespace WpfOpenDialogExample
    {
      /// <summary>
      /// An implementation independent ICommand implementation.
      /// Enables instant creation of an ICommand without implementing the ICommand interface for each command.
      /// The individual Execute() an CanExecute() members are suplied via delegates.
      /// <seealso cref="System.Windows.Input.ICommand"/>
      /// </summary>
      /// <remarks>The type of <c>RelaisCommand</c> actually is a <see cref="System.Windows.Input.ICommand"/></remarks>
        public class RelayCommand : ICommand
        {
          /// <summary>
          /// Default constructor to declare the concrete implementation of Execute(object):void and CanExecute(object) : bool
          /// </summary>
          /// <param name="executeDelegate">Delegate referencing the execution context method. 
          /// Delegate signature: delegate(object):void</param>
          /// <param name="canExecuteDelegate">Delegate referencing the canExecute context method.
          /// Delegate signature: delegate(object):bool</param>
          public RelayCommand(Action<object> executeDelegate , Predicate<object> canExecuteDelegate)
          {
            this.executeDelegate = executeDelegate;
            this.canExecuteDelegate = canExecuteDelegate;
          }
    
          /// <summary>
          /// Invokes the custom <c>canExecuteDelegate</c> which should check wether the command can be executed.
          /// </summary>
          /// <param name="parameter">Optional parameter of type <see cref="System.Object"/></param>
          /// <returns>Expected to return tue, when the preconditions meet the requirements and therefore the command stored in <c>executeDelegate</c> can execute.
          /// Expected to return fals when command execution is not possible.</returns>
          public bool CanExecute(object parameter)
          {
            if (this.canExecuteDelegate != null)
            {
              return this.canExecuteDelegate(parameter);
            }
            return false;
          }
    
          /// <summary>
          /// Invokes the custom <c>executeDelegate</c>, which references the command to execute.
          /// </summary>
          /// <param name="parameter">Optional parameter of type <see cref="System.Object"/></param>
          public void Execute(object parameter)
          {
            if (this.executeDelegate != null)
              this.executeDelegate(parameter);
          }
    
          /// <summary>
          /// The event is triggered every time the conditions regarding the command have changed. This occures when <c>InvalidateRequerySuggested()</c> gets explicitly or implicitly called.
          /// Triggering this event usually results in an invokation of <c>CanExecute(object):bool</c> to check if the occured change has made command execution possible.
          /// The <see cref="System.Windows.Input.CommandManager"/> holds a weakrefernce to the observer.
          /// </summary>
          public event EventHandler CanExecuteChanged
          {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
          }
    
          private readonly Action<object> executeDelegate;
          private readonly Predicate<object> canExecuteDelegate;
        }
    }
