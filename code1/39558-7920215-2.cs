        interface IRaiseEvents
        {
            event EventHandler ConnectionCreated;
            event EventHandler ConnectionLost;
        }
        public class SuperHandler
        {
            void RegisterEvents(IRaiseEvents raiser)
            {
                raiser.ConnectionCreated += (sender, args) => Console.WriteLine("Connected.");
                raiser.ConnectionLost += (sender, args) => Console.WriteLine("Disconnected.");
            }
        }
