    // Create a designer form with 3 buttons and a vertical trackbar and overwrite it
    // with "TestEvent" class near bottom of code, then hook up the buttons to button<1/2/3>_OnClick. 
    // Event Sibling Subscribing section explains why the first 4 event threads all fire at once.
    using System;
    using System.Windows.Forms;
    using System.Threading;
    using System.Collections.Generic;
    
    namespace TestingEventsApplication
    {
        using Extensions;
        public delegate void OnSomethingHappenedDel(MyEventArgs e);
        public delegate void EventMarshalDel(IMyEventActions sender, MyEventArgs e);
        static class Program
        {
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Console.WriteLine("Thread Main is Thread#" + Thread.CurrentThread.ManagedThreadId);
    
                int numThreads = 10;    //This controls how many threads we want to make for testing
    
                QuickSync quickSync = new QuickSync();
                MyThread[] myThreads = new MyThread[numThreads];
                TestEvent GUI = new TestEvent(myThreads);
                GUI.TrackbarVal = numThreads-1;
                for (int i = 0; i < numThreads; i++)
                {
                    myThreads[i] = new MyThread();
                    Thread thread = new Thread(delegate()
                    {
                        myThreads[i].Start(quickSync);
                    });
                    thread.Name = "Thread#" + thread.ManagedThreadId.ToString();
                    thread.IsBackground = true;
                    thread.Start();
                    while (!thread.IsAlive || !quickSync.Sync) { Thread.Sleep(1); }
                    myThreads[i].thread = thread;
                    Console.WriteLine(thread.Name + " is alive");
                    quickSync.Sync = false;
                }
    
                #region Event Sibling Subscribing
                // ********* Event Sibling Subscribing *********
                // Just for example, I will link Thread 0 to thread 1, then 1->2,2->3,3->4
                // so when thread 0 receives an event, so will thread 1, 2, 3, and 4. (Noncommutative)
                // Loops are perfectly acceptable and will not result in Eternal Events
                // e.g. 0->1 + 1->0 is OK, or 0->1 + 1->2 + 2->0... No problem.
                if (numThreads > 0)
                    myThreads[0].Event.SubscribeMeTo(myThreads[1].Event);
                //Recursively add thread 2
                if (numThreads > 1)
                    myThreads[1].Event.SubscribeMeTo(myThreads[2].Event);
                //Recursively add thread 3
                if (numThreads > 2)
                    myThreads[2].Event.SubscribeMeTo(myThreads[3].Event);
                //Recursively add thread 4
                if (numThreads > 3)
                    myThreads[3].Event.SubscribeMeTo(myThreads[4].Event);
                #endregion
    
                Application.Run(GUI);
            }
        }
    
        /// <summary>
        /// Used to determin when a task is complete.
        /// </summary>
        public class QuickSync
        {
            public bool Sync
            {
                get
                {
                    lock (this)
                    {
                        return sync;
                    }
                }
                set
                {
                    lock (this)
                    {
                        sync = value;
                    }
                }
            }
    
            private bool sync;
        }
    
        /// <summary>
        /// A class representing the operating body of a Background thread. Inherites IMyEventActions.
        /// </summary>
        /// <param name="m">a QuickSync boxed bool.</param>
        public class MyThread : IMyEventActions
        {
    
            /// <summary>
            /// An reference to the Thread object used by this thread.
            /// </summary>
            public Thread thread { get; set; }
    
            /// <summary>
            /// We can monitor the Threads msg procedure to make sure we handle messages.
            /// </summary>
            public bool AppStillIdle
            {
                get
                {
                    Win32.NativeMessage msg;
                    return !Win32.PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
                }
            }
    
            /// <summary>
            /// Tracks the MyEvent object used by the thread.
            /// </summary>
            public MyEvent Event { get; set;}
    
            /// <summary>
            /// The method used by a thread starting delegate.
            /// </summary>
            public void Start(QuickSync quickSync)
            {
                //MyEvent inherits from Form which inherits from Control which is the key to this whole thing working
                //It is the BeginInvoke method of Control which allows us to marshal objects between threads, without it
                //any event handlers would simply fire in the same thread which they were triggered.
                //We don't want to see this form though so I've moved it off screen and out of the task bar
                Event = new MyEvent();
                Event.MyEventSender = this;
                Event.SomethingHappened += new EventMarshalDel(Event.EventMarshal);
                Event.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                Event.ShowInTaskbar = false;
                Event.StartPosition = FormStartPosition.Manual;
                Event.Location = new System.Drawing.Point(-5000, -5000);
                Event.Size = new System.Drawing.Size(1, 1);
                System.Windows.Forms.Application.Idle += new EventHandler(OnApplicationIdle);
                quickSync.Sync = true;
                Application.Run(Event);
            }
    
            /// <summary>
            /// The operating body of the thread.
            /// </summary>
            private void OnApplicationIdle(object sender, EventArgs e)
            {
                while (this.AppStillIdle)
                {
                    //Do your threads work here...
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
            }
    
            /// <summary>
            /// Satisfies IMyEventActions and provides a method to implement Event actions
            /// </summary>
            public void OnSomethingHappened(MyEventArgs e)
            {
                switch ((MyEventArgs.Funcs)e.Function)
                {
                    case MyEventArgs.Funcs.Shutdown:
                        Console.WriteLine("Shutdown Event detected... " + Thread.CurrentThread.Name + " exiting");
                        Event.Close();
                        break;
                    case MyEventArgs.Funcs.SomeOtherEvent:
                        Console.WriteLine("SomeOtherEvent Event detected on " + Thread.CurrentThread.Name);
                        break;
                    case MyEventArgs.Funcs.TheLastEvent:
                        Console.WriteLine("TheLastEvent Event detected on " + Thread.CurrentThread.Name);
                        break;
                }
            }
        }
    
        /// <summary>
        /// A class housing all of the plumbing necessary to fire cross thread events.
        /// </summary>
        public class MyEvent : System.Windows.Forms.Form
        {
    
            /// <summary>
            /// Holds a reference to the object using this MyEvent, used during recursion.
            /// </summary>
            public IMyEventActions MyEventSender;
    
            /// <summary>
            /// Lock for somethingHappened delegate access.
            /// </summary>
            public readonly object someEventLock = new object();
    
            /// <summary>
            /// Delegate backing the SomethingHappened event.
            /// </summary>
            EventMarshalDel somethingHappened;// = delegate { };//Pointless overhead w/Classic null test!?!?
    
            /// <summary>
            /// Public access to the event SomethingHappened with a locking subscription mechanism for thread safety.
            /// </summary>
            // Again is this locking required in new C# ?!?! or am I just 'Cargo Cult Programming' here?
            public event EventMarshalDel SomethingHappened
            {
                add
                {
                    lock (someEventLock)
                    {
                        somethingHappened += value;
                    }
                }
                remove
                {
                    lock (someEventLock)
                    {
                        somethingHappened -= value;
                    }
                }
            }
    
            /// <summary>
            /// The trigger of MyEvent class.
            /// </summary>
            public void Fire(MyEventArgs e)
            {
                somethingHappened.RaiseEvent(MyEventSender, e);
                Thread.Sleep(1); //This is optional, but may make things more fluent.
            }
    
            /// <summary>
            /// Provides safe recursion and event propigation through siblings.
            /// </summary>
            public void Recurse(MyEventArgs e)
            {
                e.Event.Add(this);
                foreach (MyEvent m in SiblingEvents)
                {
                    if (e.Event.Contains(m)) continue; //This provides safety from Eternals
                    m.Fire(e);
                }
            }
    
            /// <summary>
            /// The Event Marshal.
            /// </summary>
            public void EventMarshal(IMyEventActions sender, MyEventArgs e)
            {
                //IMyEventActions Action = sender as IMyEventActions;
                if (null != sender)
                    if (sender.Event.InvokeRequired)
                    {
                        sender.Event.BeginInvoke(
                            new OnSomethingHappenedDel(sender.OnSomethingHappened),
                            new object[] { e });
                    }
                    else
                    {
                        sender.OnSomethingHappened(e);
                    }
    
                //If you require recursion, you need to do this...
                Recurse(e);
            }
    
            /// <summary>
            /// Adds sibling MyEvent classes which to fire synchronously.
            /// </summary>
            public void SubscribeMeTo(MyEvent m)
            {
                if (this == m) return; // We don't want to get into weird loops
                SiblingEvents.Add(m);
    
            }
    
            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                SomethingHappened -= somethingHappened;
                base.OnFormClosing(e);
            }
    
            /// <summary>
            /// A list of siblings to Eventcast.
            /// </summary>
            private List<MyEvent> SiblingEvents = new List<MyEvent>();
        }
    
        /// <summary>
        /// This is the interface used by OnSomethingHappened to arbitrate methods.
        /// </summary>
        public interface IMyEventActions
        {
            void OnSomethingHappened(MyEventArgs e);
            MyEvent Event { get; set; }
        }
    
        /// <summary>
        /// Uses a string referrable enum that references method names in MyEvent.
        /// </summary>
        public class MyEventArgs : EventArgs
        {
            public int Function { get; set; }
            public List<MyEvent> Event = new List<MyEvent>();
            public enum Funcs : int
            {
                Shutdown = 0,
                SomeOtherEvent,
                TheLastEvent
            };
    
            public MyEventArgs(string s)
            {
                this.Function = (int)Enum.Parse(typeof(Funcs), s);
            }
        }
    
        /// <summary>
        /// This is a form with 3 buttons and a trackbar on it.
        /// </summary>
        /// <param name="m">An array of MyEvent objects.</param>
        // Create a designer form with 3 buttons and a trackbar and overwrite it with this,
        // then hook up the buttons to button<1/2/3>_OnClick. 
        public partial class TestEvent : Form
        {
            public TestEvent()
            {
                InitializeComponent();
            }
    
            public TestEvent(MyThread[] t)
                : this()
            {
                myThreads = t;
            }
    
            /// <summary>
            /// This button will fire a test event, which will write to the console via MyEvent.SomeOtherEvent in another thread.
            /// </summary>
            private void button1_OnClick(object sender, EventArgs e)
            {
                Console.WriteLine("Firing SomeOtherEvent from Thread#" + Thread.CurrentThread.ManagedThreadId + " (Main)");
                myThreads[TrackbarVal].Event.Fire(new MyEventArgs("SomeOtherEvent"));
            }
    
            /// <summary>
            /// This button will fire an event, which remotelly shut down the myEvent form and kill the thread.
            /// </summary>
            private void button2_OnClick(object sender, EventArgs e)
            {
                Console.WriteLine("Firing Shutdown event from Thread#" + Thread.CurrentThread.ManagedThreadId + " (Main)");
                myThreads[TrackbarVal].Event.Fire(new MyEventArgs("Shutdown"));
            }
    
            /// <summary>
            /// This button will fire TheLastEvent, which will write to the console via MyEvent.TheLastEvent in another thread.
            /// </summary>
            private void button3_OnClick(object sender, System.EventArgs e)
            {
                Console.WriteLine("Firing TheLastEvent from Thread#" + Thread.CurrentThread.ManagedThreadId + " (Main)");
                myThreads[TrackbarVal].Event.Fire(new MyEventArgs("TheLastEvent"));
            }
    
            public int TrackbarVal
            {
                get { return this.trackBar1.Value; }
                set { this.trackBar1.Maximum = value; }
            }
    
            private MyThread[] myThreads;
        }
    }
    
    namespace Extensions
    {
        using System;
        using TestingEventsApplication;
        using System.Runtime.InteropServices;
    
        /// <summary>
        /// An extension method to null test for any OnSomethingHappened event handlers.
        /// </summary>
        public static class Extension
        {
            public static void RaiseEvent(this EventMarshalDel @event, IMyEventActions sender, MyEventArgs e)
            {
                if (@event != null)
                    @event(sender, e);
            }
    
        }
    
        /// <summary>
        /// Stores Win32 API's.
        /// </summary>
        public class Win32
        {
            /// <summary>
            /// Used to determine if there are messages waiting
            /// </summary>
            [System.Security.SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool PeekMessage(out NativeMessage message, IntPtr handle, uint filterMin, uint filterMax, uint flags);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct NativeMessage
            {
                public IntPtr handle;
                public uint msg;
                public IntPtr wParam;
                public IntPtr lParam;
                public uint time;
                public System.Drawing.Point p;
            }
        }
    }
