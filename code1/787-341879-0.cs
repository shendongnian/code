    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public class MainForm : Form
        {
            private TypeWithAsync _type;
            [STAThread()]
            public static void Main()
            {
                Application.EnableVisualStyles();
                Application.Run(new MainForm());
            }
            public MainForm()
            {
                _type = new TypeWithAsync();
                _type.DoSomethingCompleted += DoSomethingCompleted;
                var panel = new FlowLayoutPanel() { Dock = DockStyle.Fill };
                var btn = new Button() { Text = "Synchronous" };
                btn.Click += SyncClick;
                panel.Controls.Add(btn);
                btn = new Button { Text = "Asynchronous" };
                btn.Click += AsyncClick;
                panel.Controls.Add(btn);
                Controls.Add(panel);
            }
            private void SyncClick(object sender, EventArgs e)
            {
                int value = _type.DoSomething();
                MessageBox.Show(string.Format("DoSomething() returned {0}.", value));
            }
            private void AsyncClick(object sender, EventArgs e)
            {
                _type.DoSomethingAsync();
            }
            private void DoSomethingCompleted(object sender, DoSomethingCompletedEventArgs e)
            {
                MessageBox.Show(string.Format("DoSomethingAsync() returned {0}.", e.Value));
            }
        }
        class TypeWithAsync
        {
            private AsyncOperation _operation;
            // synchronous version of method
            public int DoSomething()
            {
                Thread.Sleep(5000);
                return 27;
            }
            // async version of method
            public void DoSomethingAsync()
            {
                if (_operation != null)
                {
                    throw new InvalidOperationException("An async operation is already running.");
                }
                _operation = AsyncOperationManager.CreateOperation(null);
                ThreadPool.QueueUserWorkItem(DoSomethingAsyncCore);
            }
            // wrapper used by async method to call sync version of method, matches WaitCallback so it
            // can be queued by the thread pool
            private void DoSomethingAsyncCore(object state)
            {
                int returnValue = DoSomething();
                var e = new DoSomethingCompletedEventArgs(returnValue);
                _operation.PostOperationCompleted(RaiseDoSomethingCompleted, e);
            }
            // wrapper used so async method can raise the event; matches SendOrPostCallback
            private void RaiseDoSomethingCompleted(object args)
            {
                OnDoSomethingCompleted((DoSomethingCompletedEventArgs)args);
            }
            private void OnDoSomethingCompleted(DoSomethingCompletedEventArgs e)
            {
                var handler = DoSomethingCompleted;
                if (handler != null) { handler(this, e); }
            }
            public EventHandler<DoSomethingCompletedEventArgs> DoSomethingCompleted;
        }
        public class DoSomethingCompletedEventArgs : EventArgs
        {
            private int _value;
            public DoSomethingCompletedEventArgs(int value)
                : base()
            {
                _value = value;
            }
            public int Value
            {
                get { return _value; }
            }
        }
    }
