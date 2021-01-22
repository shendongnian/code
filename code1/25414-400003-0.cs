    using System;
    using System.Collections.Generic;
    
    namespace EventExperiment
    {
        class Program
        {
            static void Main(string[] args)
            {
                IEventOwner e=new EventOwner2();
                Subscriber s=new Subscriber(e);
                e.RaiseSome();
                Console.ReadKey();
            }
        }
    
        /// <summary>
        /// A consumer class, subscribing twice to the event in it's constructor.
        /// </summary>
        public class Subscriber
        {
            public Subscriber(IEventOwner eventOwner)
            {
                eventOwner.SomeEvent += eventOwner_SomeEvent;
                eventOwner.SomeEvent += eventOwner_SomeEvent;
            }
    
            void eventOwner_SomeEvent(object sender, EventArgs e)
            {
                Console.WriteLine(DateTimeOffset.Now);
            }
    
        }
    
        /// <summary>
        /// This interface is not essensial to this point. it is just added for conveniance.
        /// </summary>
        public interface IEventOwner
        {
            event EventHandler<EventArgs> SomeEvent;
            void RaiseSome();
        }
    
        /// <summary>
        /// A traditional event. This is raised for each subscription.
        /// </summary>
        public class EventOwner1 : IEventOwner
        {
            public event EventHandler<EventArgs> SomeEvent = delegate { };
            public void RaiseSome()
            {
                SomeEvent(this,new EventArgs());
            }
        }
        /// <summary>
        /// A custom event. This is raised only once for each subscriber.
        /// </summary>
        public class EventOwner2 : IEventOwner
        {
            private readonly List<EventHandler<EventArgs>> handlers=new List<EventHandler<EventArgs>>();
            public event EventHandler<EventArgs> SomeEvent
            {
                add
                {
                    lock (handlers)
                        if (handlers!=null&&!handlers.Contains(value))
                        {
                            handlers.Add(value);
                        }
                }
                remove
                {
                    handlers.Remove(value);
                }
            }
            public void RaiseSome()
            {
                EventArgs args=new EventArgs();
                lock(handlers)
                foreach (EventHandler<EventArgs> handler in handlers)
                {
                    handler(this,args);
                }
            }
        }
    }
