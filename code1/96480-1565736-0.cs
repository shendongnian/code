    using System;
    using System.Threading;
    interface IGroundUser
    {
        bool Invoke(); // do your stuff; return true to wake up *everyone*
                       // afterwards, else false
    }
    class Team : IGroundUser
    {
        private readonly string name;
        public Team(string name) { this.name = name; }
        public override string ToString() { return name; }
        public bool Invoke()
        {
            Console.WriteLine(name + ": playing...");
            Thread.Sleep(25 * 250);
            Console.WriteLine(name + ": leaving...");
            return false;
        }
    }
    class Cleaner : IGroundUser
    {
        public override string ToString() {return "cleaner";}
        public bool Invoke()
        {
            Console.WriteLine("cleaning in progress");
            Thread.Sleep(10 * 250);
            Console.WriteLine("cleaning complete");
            return true;
        }
    }
    class FootBallGround
    {
        static void Main()
        {
            var ground = new FootBallGround();
            ThreadPool.QueueUserWorkItem(delegate { ground.UseGrounds(new Team("Team A")); });
            ThreadPool.QueueUserWorkItem(delegate { ground.UseGrounds(new Team("Team B")); });
            ThreadPool.QueueUserWorkItem(delegate { ground.UseGrounds(new Cleaner()); });
            ThreadPool.QueueUserWorkItem(delegate { ground.UseGrounds(new Team("Team C")); });
            ThreadPool.QueueUserWorkItem(delegate { ground.UseGrounds(new Team("Team D")); });
            ThreadPool.QueueUserWorkItem(delegate { ground.UseGrounds(new Team("Team E")); });
            Console.ReadLine();
           
        }
        bool busy;
        private readonly object syncLock = new object();
        public void UseGrounds(IGroundUser newUser)
        {
            // validate outside of lock
            if (newUser == null) throw new ArgumentNullException("newUser");
            // only need the lock when **changing** state
            lock (syncLock)
            {
                while (busy)
                {
                    Console.WriteLine(newUser + ": grounds are busy; waiting...");
                    Monitor.Wait(syncLock);
                    Console.WriteLine(newUser + ": got nudged");
                }
                busy = true; // we've got it!
            }
            // do this outside the lock, allowing other users to queue
            // waiting for it to be free
            bool wakeAll = newUser.Invoke();
    
            // exit the game
            lock (syncLock)
            {
                busy = false;
                // wake up somebody (or everyone with PulseAll)
                if (wakeAll) Monitor.PulseAll(syncLock);
                else Monitor.Pulse(syncLock);
            }
        }    
    }    
