    using System;
    using System.Threading;
    class App {
       static void Main() {
          // Construct an instance of the App object
          App a = new App();
          // This malicious code enters a lock on 
          // the object but never exits the lock
          Monitor.Enter(a);
          // For demonstration purposes, let's release the 
          // root to this object and force a garbage collection
          a = null;
          GC.Collect();
          // For demonstration purposes, wait until all Finalize
          // methods have completed their execution - deadlock!
          GC.WaitForPendingFinalizers();
          // We never get to the line of code below!
          Console.WriteLine("Leaving Main");
       }
       // This is the App type's Finalize method
       ~App() {
          // For demonstration purposes, have the CLR's 
          // Finalizer thread attempt to lock the object.
          // NOTE: Since the Main thread owns the lock, 
          // the Finalizer thread is deadlocked!
          lock (this) {
             // Pretend to do something in here...
          }
       }
    }
