    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    public partial class frmWorker : Form {
      public frmWorker() {
        // Start the worker thread
        Thread t = new Thread(new ParameterizedThreadStart(WorkerThread));
        t.IsBackground = true;
        t.Start(this);
      }
      public void Stop() {
        // Synchronous thread stop
        this.Invoke(new MethodInvoker(stopWorker), null);
      }
      private void stopWorker() {
        this.Close();
      }
      private static void WorkerThread(object frm) {
        // Start the message loop
        frmWorker f = frm as frmWorker;
        f.CreateHandle();
        Application.Run(f);
      }
      protected override void SetVisibleCore(bool value) {
        // Shouldn't become visible
        value = false;
        base.SetVisibleCore(value);
      }
    }
