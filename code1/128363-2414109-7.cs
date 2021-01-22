    namespace MyExample
    {
        public class Subscription
        {
            private object suscribedObject;
            private EventHandler eventHandler;
            private Subscription nextSubscription;
    
            public object SuscribedObject
            {
                set
                {
                    suscribedObject = value;
                }
            }
    
            public EventHandler EventHandler
            {
                set
                {
                    eventHandler = value;
                }
            }
    
            public Subscription NextSubscription
            {
                get
                {
                    return nextSubscription;
                }
                set
                {
                    nextSubscription = value;
                }
            }
    
            public void Subscribe(object obj)
            {
    
                if (suscribedObject == null)
                {
                    suscribedObject = obj;
                }
                else
                {
                    if (nextSubscription != null)
                    {
                        nextSubscription.Subscribe(obj);
                    }
                    else
                    {
                        Subscription newSubscription = new Subscription();
                        newSubscription.eventHandler = this.eventHandler;
                        nextSubscription = newSubscription;
                        newSubscription.Subscribe(obj);
                    }
                }
            }
    
            public void RaiseEvent()
            {
                if (eventHandler != null)
                {
                    eventHandler(suscribedObject, new System.EventArgs());
                }
            }
        }
    }
