    // Create a designer form with 3 buttons and a vertical trackbar and overwrite it
    // with "TestEvent" class near bottom of code, then hook up the buttons to button 1/2/3 _OnClick. 
    // Event Sibling Subscribing section explains why the first 4 event threads all fire at once.
    using System;
    using System.Windows.Forms;
    using System.Threading;
    using System.Collections.Generic;
    
    namespace TestingEventsApplication
    {
        using Extensions;
        public delegate void OnSomethingHappened(object sender, MyEventArgs e);
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
                MyEvent[] myEvent = new MyEvent[numThreads];
                Thread[] thread = new Thread[numThreads];
                TestEvent GUI = new TestEvent(myEvent);
                GUI.TrackbarVal = numThreads-1;
                for (int i = 0; i < numThreads; i++)
                {
                    thread[i] = new Thread(delegate()
                    {
                        new Thread1(myEvent[i] = new MyEvent(), quickSync);
                    });
                    thread[i].Name = "Thread#" + thread[i].ManagedThreadId.ToString();
                    thread[i].IsBackground = true;
                    thread[i].Start();
                    while (!thread[i].IsAlive || !quickSync.Sync) { Thread.Sleep(1); }
                    Thread.Sleep(50); //reduce chance of bad sync anomalies
                    Console.WriteLine(thread[i].Name + " is alive");
                    quickSync.Sync = false;
                }
                for (int i = 0; i < numThreads; i++)
                {
                    // I don't think it's possible for a failure like this anymore
                    // but it happened a couple times in my earlier development
                    // I haven't seen it since but I left this routine here to detect it
                    if (myEvent[i] == null)
                    {
                        Console.WriteLine("bad sync anomaly detected on #" + i);
                        Application.Exit();
                    }
                }
    
                #region Event Sibling Subscribing
                // ********* Event Sibling Subscribing *********
                // Just for example, I will link Thread 0 to thread 1, then 1->2,2->3,3->4
                // so when thread 0 receives an event, so will thread 1, 2, and 3. (Noncommutative)
                // Loops are perfectly acceptable and will not result in Eternal Events
                // e.g. 0->1 + 1->0 is OK, or 0->1 + 1->2 + 2->0... No problem.
                if (numThreads > 0)
                    myEvent[0].SubscribeMeTo(myEvent[1]);
                //Recursively add thread 2
                if (numThreads > 1)
                    myEvent[1].SubscribeMeTo(myEvent[2]);
                //Recursively add thread 3
                if (numThreads > 2)
                    myEvent[2].SubscribeMeTo(myEvent[3]);
                //Recursively add thread 4
                if (numThreads > 3)
                    myEvent[3].SubscribeMeTo(myEvent[4]);
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
        /// This is the class where a Background thread lives.
        /// </summary>
        /// <param name="m">a MyEvent object.</param>
        /// <param name="m">a QuickSync boxed bool.</param>
        public class Thread1
        {
            /// <summary>
            /// We can monitor the Threads msg procedure to make sure we handle messages.
            /// </summary>
            public bool AppStillIdle
            {
                get
                {
                    Extension.NativeMessage msg;
                    return !Extension.PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
                }
            }
    
            public Thread1(MyEvent m, QuickSync quickSync)
            {
                //MyEvent inherits from Form which inherits from Control which is the key to this whole thing working
                //It is the BeginInvoke method of Control which allows us to marshal objects between threads, without it
                //any event handlers would simply fire in the same thread which they were triggered.
                //We don't want to see this form though so I've moved it off screen and out of the task bar
                myEvent = m;
                myEvent.SomethingHappened += new OnSomethingHappened(myEvent.EventMarshal);
                myEvent.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                myEvent.ShowInTaskbar = false;
                myEvent.StartPosition = FormStartPosition.Manual;
                myEvent.Location = new System.Drawing.Point(-5000, -5000);
                myEvent.Size = new System.Drawing.Size(1, 1);
                System.Windows.Forms.Application.Idle += new EventHandler(OnApplicationIdle);
                quickSync.Sync = true;
                Application.Run(myEvent);
            }
    
            private void OnApplicationIdle(object sender, EventArgs e)
            {
                while (this.AppStillIdle)
                {
                    //Do your threads work here...
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
            }
    
            private MyEvent myEvent;
        }
    
        /// <summary>
        /// A class housing all of the plumbing necessary to fire cross thread events.
        /// </summary>
        public class MyEvent : System.Windows.Forms.Form, IMyEventActions
        {
            /// <summary>
            /// Lock for somethingHappened delegate access.
            /// </summary>
            public readonly object someEventLock = new object();
    
            /// <summary>
            /// Delegate backing the SomethingHappened event.
            /// </summary>
            OnSomethingHappened somethingHappened;// = delegate { };//Pointless overhead w/Classic null test!?!?
    
            /// <summary>
            /// Public access to the event SomethingHappened with a locking subscription mechanism for thread safety.
            /// </summary>
            // Again is this locking required in new C# ?!?! or am I just 'Cargo Cult Programming' here?
            public event OnSomethingHappened SomethingHappened
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
            /// A list of siblings to Eventcast.
            /// </summary>
            private List<MyEvent> SiblingEvents = new List<MyEvent>();
    
            /// <summary>
            /// The trigger of MyEvent class.
            /// </summary>
            public void Fire(MyEventArgs e)
            {
                somethingHappened.RaiseEvent(this, e);
                Thread.Sleep(1); //This is optional, but may make things more fluid.
            }
    
            /// <summary>
            /// The event result arbiter.
            /// </summary>
            private static void OnSomethingHappened(object sender, MyEventArgs e)
            {
                IMyEventActions EventActions = sender as IMyEventActions;
                if (null != EventActions)
                {
                    switch ((MyEventArgs.Funcs)e.Function)
                    {
                        case MyEventArgs.Funcs.Shutdown:
                            EventActions.Shutdown(e);
                            break;
                        case MyEventArgs.Funcs.SomeOtherEvent:
                            EventActions.SomeOtherEvent(e);
                            break;
                        case MyEventArgs.Funcs.TheLastEvent:
                            EventActions.TheLastEvent(e);
                            break;
                    }
                }
            }
    
            /// <summary>
            /// Unsubscribes the event and closes the form used to marshal events as it exits the thread.
            /// </summary>
            public void Shutdown(MyEventArgs e)
            {
                //if (this.InvokeRequired) return; //This adds some additional cross thread safety,
                //but I have never encountered a scenario where I needed to use it
                Console.WriteLine("Shutdown Event detected... " + Thread.CurrentThread.Name + " exiting");
                this.Close();
                SomethingHappened -= somethingHappened;
    
                //If you require recursion, you need to do this...
                Recurse(e);
            }
    
            /// <summary>
            /// An example event method
            /// </summary>
            public void SomeOtherEvent(MyEventArgs e)
            {
                Console.WriteLine("SomeOtherEvent Event detected on " + Thread.CurrentThread.Name);
                Recurse(e);
            }
    
            /// <summary>
            /// An example event method
            /// </summary>
            public void TheLastEvent(MyEventArgs e)
            {
                Console.WriteLine("TheLastEvent Event detected on " + Thread.CurrentThread.Name);
                Recurse(e);
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
            public void EventMarshal(object sender, MyEventArgs e)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(
                        new OnSomethingHappened(OnSomethingHappened),
                        new object[] { sender, e });
                }
                else
                {
                    OnSomethingHappened(sender, e);
                }
            }
    
            /// <summary>
            /// Adds sibling MyEvent classes which to fire synchronously.
            /// </summary>
            public void SubscribeMeTo(MyEvent m)
            {
                if (this == m) return; // We don't want to get into nasty loops
                SiblingEvents.Add(m);
    
            }
        }
    
        /// <summary>
        /// This is the interface used by OnSomethingHappened to arbitrate methods.
        /// </summary>
        public interface IMyEventActions
        {
            void Shutdown(MyEventArgs e);
            void SomeOtherEvent(MyEventArgs e);
            void TheLastEvent(MyEventArgs e);
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
    
            public TestEvent(MyEvent[] m)
                : this()
            {
                myEvent = m;
            }
    
            /// <summary>
            /// This button will fire a test event, which will write to the console via MyEvent.SomeOtherEvent in another thread.
            /// </summary>
            private void button1_OnClick(object sender, EventArgs e)
            {
                Console.WriteLine("Firing SomeOtherEvent from Thread#" + Thread.CurrentThread.ManagedThreadId + " (Main)");
                myEvent[TrackbarVal].Fire(new MyEventArgs("SomeOtherEvent"));
            }
    
            /// <summary>
            /// This button will fire an event, which remotelly shut down the myEvent form and kill the thread.
            /// </summary>
            private void button2_OnClick(object sender, EventArgs e)
            {
                Console.WriteLine("Firing Shutdown event from Thread#" + Thread.CurrentThread.ManagedThreadId + " (Main)");
                myEvent[TrackbarVal].Fire(new MyEventArgs("Shutdown"));
            }
    
            /// <summary>
            /// This button will fire TheLastEvent, which will write to the console via MyEvent.TheLastEvent in another thread.
            /// </summary>
            private void button3_OnClick(object sender, System.EventArgs e)
            {
                Console.WriteLine("Firing TheLastEvent from Thread#" + Thread.CurrentThread.ManagedThreadId + " (Main)");
                myEvent[TrackbarVal].Fire(new MyEventArgs("TheLastEvent"));
            }
    
            public int TrackbarVal
            {
                get { return this.trackBar1.Value; }
                set { this.trackBar1.Maximum = value; }
            }
    
            private MyEvent[] myEvent;
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
            public static void RaiseEvent(this OnSomethingHappened @event, object sender, MyEventArgs e)
            {
                if (@event != null)
                    @event(sender, e);
            }
    
            // You might want to move this to it's own Win32 container, I just stuck it here...
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
