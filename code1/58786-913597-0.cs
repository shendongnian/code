            public class EventThrower
            {
                public delegate void EventHandler(object sender, EventArgs args) ;
                public event EventHandler ThrowEvent = delegate{};
    
                public void SomethingHappened()
                {
                    ThrowEvent(this, new EventArgs());
                }
            }
    
            public class EventSubscriber
            {
                private EventThrower _Thrower;
    
                public EventSubscriber()
                {
                    _Thrower = new EventThrower();
                    //using lambda expression..could use method like other answers on here
                    _Thrower.ThrowEvent += (sender, args) => { DoSomething(); };
                }
    
                private void DoSomething()
                {
                   //Handle event.....
                }
            }
