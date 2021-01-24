    using System;
    using System.Linq;
    using System.Threading;
    
    namespace so_example
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var person1 = new Being("Human 1", new HumanBrain(), new HumanStomach());
                var zombie1 = new Being("Zombie 1", new ZombieBrain(), new ZombieStomach());
                var hybrid1 = new Being("Hybrid 1", new ZombieBrain(), new HumanStomach());
                var hybrid2 = new Being("Hybrid 2", new HumanBrain(), new ZombieStomach());
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    
        public class HungryEventArgs : EventArgs
        {
            public string Message { get; set; }
        }
    
        public interface IStomach
        {
            event EventHandler<HungryEventArgs> NeedsFoodEvent;
        }
    
        public class Stomach : IStomach
        {
            public event EventHandler<HungryEventArgs> NeedsFoodEvent;
    
            protected virtual void OnRaiseNeedsFoodEvent(HungryEventArgs e)
            {
                EventHandler<HungryEventArgs> handler = NeedsFoodEvent;
    
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }
    
        public class HumanStomach : Stomach
        {
            private Timer _hungerTimer;
    
            public HumanStomach()
            {
                _hungerTimer = new Timer(o =>
                {
                    // only trigger if breakfast, lunch or dinner (24h notation)
                    if (new [] { 8, 13, 19 }.Any(t => t == DateTime.Now.Hour))
                    {
                        OnRaiseNeedsFoodEvent(new HungryEventArgs { Message = "I'm empty!" });
                    }
                    else
                    {
                        Console.WriteLine("It's not mealtime");
                    }
                }, null, 1000, 1000);
            }
        }
    
        public class ZombieStomach : Stomach
        {
            private Timer _hungerTimer;
    
            public ZombieStomach()
            {
                _hungerTimer = new Timer(o =>
                {
                    OnRaiseNeedsFoodEvent(new HungryEventArgs { Message = "Need brains in stomach!" });
                }, null, 1000, 1000);
            }
        }
    
        public interface IBrain
        {
            event EventHandler<HungryEventArgs> IsHungryEvent;
            void OnRaiseIsHungryEvent();
        }
    
        public class Brain : IBrain
        {
            public event EventHandler<HungryEventArgs> IsHungryEvent;
            protected string _hungryMessage;
    
            public void OnRaiseIsHungryEvent()
            {
                EventHandler<HungryEventArgs> handler = IsHungryEvent;
    
                if (handler != null)
                {
                    var e = new HungryEventArgs
                    {
                    Message = _hungryMessage
                    };
    
                    handler(this, e);
                }
            }
        }
    
        public class HumanBrain : Brain
        {
            public HumanBrain()
            {
                _hungryMessage = "Need food!";
            }
        }
    
        public class ZombieBrain : Brain
        {
            public ZombieBrain()
            {
                _hungryMessage = "Braaaaaains!";
            }
        }
    
        public class Being
        {
            protected readonly IBrain _brain;
            protected readonly IStomach _stomach;
            private readonly string _name;
    
            public Being(string name, IBrain brain, IStomach stomach)
            {
                _stomach = stomach;
                _brain = brain;
                _name = name;
    
                _stomach.NeedsFoodEvent += (s, e) =>
                {
                    Console.WriteLine($"{_name}: {e.Message}");
                    _brain.OnRaiseIsHungryEvent();
                };
    
                _brain.IsHungryEvent += (s, e) =>
                {
                    Console.WriteLine($"{_name}: {e.Message}");
                };
            }
        }
    }
