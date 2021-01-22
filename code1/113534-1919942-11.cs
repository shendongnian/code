    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Timer=System.Threading.Timer;
    namespace LockTest
    {
        public static class Program
        {
            // Used by component's notification event
            private sealed class MyEventArgs : EventArgs
            {
                public string NotificationText { get; set; }
            }
            // Simple component implementation; fires notification event 500 msecs after previous notification event finished
            private sealed class MyComponent
            {
                public MyComponent()
                {
                    this._timer = new Timer(this.Notify, null, -1, -1); // not started yet
                }
                public void Start()
                {
                    lock (this._lock)
                    {
                        if (!this._active)
                        {
                            this._active = true;
                            this._timer.Change(TimeSpan.FromMilliseconds(500d), TimeSpan.FromMilliseconds(-1d));
                        }
                    }
                }
                public void Stop()
                {
                    lock (this._lock)
                    {
                        this._active = false;
                    }
                }
                public event EventHandler<MyEventArgs> Notification;
                private void Notify(object ignore) // this will be invoked invoked in the context of a threadpool worker thread
                {
                    lock (this._lock)
                    {
                        if (!this._active) { return; }
                        var notification = this.Notification; // make a local copy
                        if (notification != null)
                        {
                            notification(this, new MyEventArgs { NotificationText = "Now is " + DateTime.Now.ToString("o") });
                        }
                        this._timer.Change(TimeSpan.FromMilliseconds(500d), TimeSpan.FromMilliseconds(-1d)); // rinse and repeat
                    }
                }
                private bool _active;
                private readonly object _lock = new object();
                private readonly Timer _timer;
            }
            // Simple form to excercise our component
            private sealed class MyForm : Form
            {
                public MyForm()
                {
                    this.Text = "UI Lock Demo";
                    this.AutoSize = true;
                    this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    var container = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
                    this.Controls.Add(container);
                    this._status = new Label { Width = 300, Text = "Ready, press Start" };
                    container.Controls.Add(this._status);
                    this._component.Notification += this.UpdateStatus;
                    var button = new Button { Text = "Start" };
                    button.Click += (sender, args) => this._component.Start();
                    container.Controls.Add(button);
                    button = new Button { Text = "Stop" };
                    button.Click += (sender, args) => this._component.Stop();
                    container.Controls.Add(button);
                }
                private void UpdateStatus(object sender, MyEventArgs args)
                {
                    if (this.InvokeRequired)
                    {
                        Thread.Sleep(2000);
                        this.Invoke(new EventHandler<MyEventArgs>(this.UpdateStatus), sender, args);
                    }
                    else
                    {
                        this._status.Text = args.NotificationText;
                    }
                }
                private readonly Label _status;
                private readonly MyComponent _component = new MyComponent();
            }
            // Program entry point, runs event loop for the form that excercises out component
            public static void Main(string[] args)
            {
                Control.CheckForIllegalCrossThreadCalls = true;
                Application.EnableVisualStyles();
                using (var form = new MyForm())
                {
                    Application.Run(form);
                }
            }
        }
    }
