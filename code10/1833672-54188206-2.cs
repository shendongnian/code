    using System;
    using System.Threading;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            Sender s = new Sender();
            using (Listener l = new Listener(s))
            {
                s.BeginDemonstration();
            }
        }
    }
    class Sender
    {
        const int ATTEMPTED_CALLS = 1000000;
        internal EventHandler frequencyReducedHandler;
        internal int actualCalls = 0;
        internal int ignoredCalls = 0;
        Task[] tasks = new Task[ATTEMPTED_CALLS];
        internal void BeginDemonstration()
        {
            int attemptedCalls;
            for (attemptedCalls = 0; attemptedCalls < ATTEMPTED_CALLS; attemptedCalls++)
            {
                tasks[attemptedCalls] = Task.Run(() => frequencyReducedHandler.Invoke(this, EventArgs.Empty));
                //frequencyReducedHandler?.BeginInvoke(this, EventArgs.Empty, null, null);
            }
            if (tasks[0] != null)
            {
                Task.WaitAll(tasks, Timeout.Infinite);
            }
            Console.WriteLine($"Attempted: {attemptedCalls}\tActual: {actualCalls}\tIgnored: {ignoredCalls}");
            Console.ReadKey();
        }
    }
    class Listener : IDisposable
    {
        enum State
        {
            Waiting,
            Running,
            Queued
        }
        private readonly AutoResetEvent m_SingleEntry = new AutoResetEvent(true);
        private readonly Sender m_Sender;
        private int m_CurrentState = (int)State.Waiting;
        internal Listener(Sender sender)
        {
            m_Sender = sender;
            m_Sender.frequencyReducedHandler += Handler;
        }
        private async void Handler(object sender, EventArgs args)
        {
            int state = Interlocked.Increment(ref m_CurrentState);
            try
            {
                if (state <= (int)State.Queued) // Previous state was WAITING or RUNNING
                {
                    // Ensure only one run at a time
                    m_SingleEntry.WaitOne();
                    try
                    {
                        // Only one thread at a time here so
                        // no need for Interlocked.Increment
                        m_Sender.actualCalls++;
                        // Execute CPU intensive task
                        await Task.Delay(500);
                    }
                    finally
                    {
                        // Allow a waiting thread to proceed
                        m_SingleEntry.Set();
                    }
                }
                else
                {
                    Interlocked.Increment(ref m_Sender.ignoredCalls);
                }
            }
            finally
            {
                Interlocked.Decrement(ref m_CurrentState);
            }
        }
        public void Dispose()
        {
            m_SingleEntry?.Dispose();
        }
    }
