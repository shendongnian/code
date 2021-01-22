       // Homemade Action-style delegates to provide .Net 2.0 compatibility, since .Net 2.0 does not 
       //  include a non-generic Action delegate nor Action delegates with more than one generic type 
       //  parameter. (The DMethodWithOneParameter<T> definition is not needed, could be Action<T> 
       //  instead, but is defined for consistency.) Some interesting observations can be found here:
       //  http://geekswithblogs.net/BlackRabbitCoder/archive/2011/11/03/c.net-little-wonders-the-generic-action-delegates.aspx
       public delegate void DMethodWithNoParameters();
       public delegate void DMethodWithOneParameter<T>(T parameter1);
       public delegate void DMethodWithTwoParameters<T1, T2>(T1 parameter1, T2 parameter2);
       public delegate void DMethodWithThreeParameters<T1, T2, T3>(T1 parameter1, T2 parameter2, T3 parameter3);
    
    
       /// <summary>
       /// Class containing support code to use the SynchronizationContext mechanism to dispatch the 
       /// execution of a method to the WinForms UI thread, from another thread. This can be used as an 
       /// alternative to the Control.BeginInvoke() mechanism which can be problematic under certain 
       /// conditions. See for example the discussion here:
       /// http://stackoverflow.com/questions/1364116/avoiding-the-woes-of-invoke-begininvoke-in-cross-thread-winform-event-handling
       ///
       /// As currently coded this works with methods that take zero, one, two or three arguments, but 
       /// it is a trivial job to extend the code for methods taking more arguments.
       /// </summary>
       public class WinFormsHelper
       {
          // An arbitrary WinForms control associated with thread 1, used to check that thread-switching 
          //  with the SynchronizationContext mechanism should be OK
          private readonly Control _thread1Control = null;
    
          // SynchronizationContext for the WinForms environment's UI thread
          private readonly WindowsFormsSynchronizationContext _synchronizationContext;
    
    
          /// <summary>
          /// Constructor. This must be called on the WinForms UI thread, typically thread 1. (Unless 
          /// running under the Visual Studio debugger, then the thread number is arbitrary.)
          ///
          /// The provided "thread 1 control" must be some WinForms control that will remain in 
          /// existence for as long as this object is going to be used, for example the main Form 
          /// control for the application.
          /// </summary>
          /// <param name="thread1Control">see above</param>
          public WinFormsHelper(Control thread1Control)
          {
             _thread1Control = thread1Control;
             if (thread1Control.InvokeRequired)
                throw new Exception("Not called on thread associated with WinForms controls.");
    
             _synchronizationContext =
                                SynchronizationContext.Current as WindowsFormsSynchronizationContext;
             if (_synchronizationContext == null) // Should not be possible?
                throw new Exception("SynchronizationContext.Current = null or wrong type.");
          }
    
    
          // The following BeginInvoke() methods follow a boilerplate pattern for how these methods 
          // should be implemented - they differ only in the number of arguments that the caller wants 
          // to provide.
    
          public void BeginInvoke(DMethodWithNoParameters methodWithNoParameters)
          {
             _synchronizationContext.Post((object stateNotUsed) =>
             {
                if (!_thread1Control.IsDisposed)
                   methodWithNoParameters();
             }, null);
          }
    
    
          public void BeginInvoke<T>(DMethodWithOneParameter<T> methodWithOneParameter, T parameter1)
          {
             _synchronizationContext.Post((object stateNotUsed) =>
             {
                if (!_thread1Control.IsDisposed)
                   methodWithOneParameter(parameter1);
             }, null);
          }
    
    
          public void BeginInvoke<T1, T2>(DMethodWithTwoParameters<T1, T2> methodWithTwoParameters,
                                          T1 parameter1, T2 parameter2)
          {
             _synchronizationContext.Post((object stateNotUsed) =>
             {
                if (!_thread1Control.IsDisposed)
                   methodWithTwoParameters(parameter1, parameter2);
             }, null);
          }
    
    
          public void BeginInvoke<T1, T2, T3>(DMethodWithThreeParameters<T1, T2, T3> methodWithThreeParameters,
                                              T1 parameter1, T2 parameter2, T3 parameter3)
          {
             _synchronizationContext.Post((object stateNotUsed) =>
             {
                if (!_thread1Control.IsDisposed)
                   methodWithThreeParameters(parameter1, parameter2, parameter3);
             }, null);
          }
       }
