    using System;
    using System.Threading;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            Sender s = new Sender();
            Listener l = new Listener(s);
            s.BeginDemonstration();
        }
    }
    class Sender
    {
        internal EventHandler frequencyReducedHandler;
    internal int actualCalls = 0;
    internal void BeginDemonstration()
        {
            int attemptedCalls;
            for (attemptedCalls = 0; attemptedCalls < 1000000; attemptedCalls++)
            {
                frequencyReducedHandler?.BeginInvoke(this, EventArgs.Empty, null, null);
            }
        Console.WriteLine($"Attempted: {attemptedCalls}\tActual: {actualCalls}");
        Console.ReadKey();
        }
    }
    class Listener
    {
        const int WAITING = 0;
        const int RUNNING = 1;
        private readonly Sender m_Sender;
        private int m_CurrentState = WAITING;
        internal Listener(Sender sender)
        {
            m_Sender = sender;
            m_Sender.frequencyReducedHandler += Handler;
        }
        private async void Handler(object sender, EventArgs args)
        {
            int state = Interlocked.CompareExchange(ref m_CurrentState, RUNNING, WAITING);
            if (state == WAITING)
            {
            // Previous state was waiting, so go ahead and execute
            m_Sender.actualCalls++;
            await Task.Delay(500);
                Interlocked.Exchange(ref m_CurrentState, WAITING);
            }
        }
    }
