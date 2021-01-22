    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    static class ClientView {
        private static Form mView;
    
        public static void Start(Form view) {
            if (Busy) throw new InvalidOperationException("View already running");
            mView = view;
            mView.FormClosed += (o, e) => { mView = null; }
            Thread t = new Thread(() => Application.Run(view));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        public static void Stop() {
            if (Busy) mView.Invoke(new MethodInvoker(() => mView.Close()));
        }
        public static bool Busy { get { return mView != null; } }
    }
