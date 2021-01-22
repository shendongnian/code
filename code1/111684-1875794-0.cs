    using System;
    using System.Runtime.Remoting.Messaging;
    
    class Program {
      static void Main(string[] args) {
        new Program().Run();
        Console.ReadLine();
      }
      void Run() {
        Action example = new Action(threaded);
        IAsyncResult ia = example.BeginInvoke(new AsyncCallback(completed), null);
        // Option #1:
        /*
        ia.AsyncWaitHandle.WaitOne();
        try {
          example.EndInvoke(ia);
        }
        catch (ApplicationException ex) {
          Console.WriteLine(ex.Message);
        }
        */
      }
    
      void threaded() {
        throw new ApplicationException("Kaboom");
      }
    
      void completed(IAsyncResult ar) {
        // Option #2:
        Action example = (ar as AsyncResult).AsyncDelegate as Action;
        try {
          example.EndInvoke(ar);
        }
        catch (ApplicationException ex) {
          Console.WriteLine(ex.Message);
        }
      }
    }
