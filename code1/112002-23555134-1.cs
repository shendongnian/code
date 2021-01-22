    namespace ManagedHelpers.Threads
       {
       using System;
       using System.Collections.Generic;
       using System.Diagnostics;
       using System.Linq;
       using System.Text;
       using System.Threading;
       using System.Threading.Tasks;
       using System.Windows.Forms;
       using NUnit.Framework;
    
       public class STASynchronizationContext : SynchronizationContext, IDisposable
          {
          private readonly Control control;
          private readonly int mainThreadId;
    
          public STASynchronizationContext()
             {
             this.control = new Control();
    
             this.control.CreateControl();
    
             this.mainThreadId = Thread.CurrentThread.ManagedThreadId;
    
             if (Thread.CurrentThread.Name == null)
                {
                Thread.CurrentThread.Name = "AsynchronousTestRunner Main Thread";
                }
             }
    
          public override void Post(SendOrPostCallback d, object state)
             {
             control.BeginInvoke(d, new object[] { state });
             }
    
          public override void Send(SendOrPostCallback d, object state)
             {
             control.Invoke(d, new object[] { state });
             }
    
          public void Dispose()
             {
             Assert.AreEqual(this.mainThreadId, Thread.CurrentThread.ManagedThreadId);
    
             this.Dispose(true);
             GC.SuppressFinalize(this);
             }
    
          protected virtual void Dispose(bool disposing)
             {
             Assert.AreEqual(this.mainThreadId, Thread.CurrentThread.ManagedThreadId);
    
             if (disposing)
                {
                if (control != null)
                   {
                   control.Dispose();
                   }
                }
             }
    
          ~STASynchronizationContext()
             {
             this.Dispose(false);
             }
          }
       }
