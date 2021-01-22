    public class Program
    {
        private static List<EventHandler<CancelEventArgs>> SubscribersList = new List<EventHandler<CancelEventArgs>>();
        
        public static event EventHandler<CancelEventArgs> TheEvent
        {
            add {
                if (!SubscribersList.Contains(value))
                {
                    SubscribersList.Add(value);
                }
            }
            remove
            {
                if (SubscribersList.Contains(value))
                {
                    SubscribersList.Remove(value);
                }
            }
        }
        public static void RaiseTheEvent(object sender, CancelEventArgs cancelArgs)
        {
            foreach (EventHandler<CancelEventArgs> sub in SubscribersList)
            {
                sub(sender, cancelArgs);
                // Stop the Execution after a subscriber cancels the event
                if (cancelArgs.Cancel)
                {
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            new Subscriber1();
            new Subscriber2();
            Console.WriteLine("Program: Raising the event");
            CancelEventArgs cancelArgs = new CancelEventArgs();
            RaiseTheEvent(null, cancelArgs);
            if (cancelArgs.Cancel)
            {
                Console.WriteLine("Program: The Event was Canceled");
            }
            else
            {
                Console.WriteLine("Program: The Event was NOT Canceled");
            }
            Console.ReadLine();
        }
    }
    public class Subscriber1
    {
        public Subscriber1()
        {
            Program.TheEvent += new EventHandler<CancelEventArgs>(program_TheEvent);
        }
        void program_TheEvent(object sender, CancelEventArgs e)
        {
            Console.WriteLine("Subscriber1: in program_TheEvent");
            Console.WriteLine("Subscriber1: Canceling the event");
            e.Cancel = true;
        }
    }
    public class Subscriber2
    {
        public Subscriber2()
        {
            Program.TheEvent += new EventHandler<CancelEventArgs>(program_TheEvent);
        }
        void program_TheEvent(object sender, CancelEventArgs e)
        {
            Console.WriteLine("Subscriber2: in program_TheEvent");
            
        }
    }
