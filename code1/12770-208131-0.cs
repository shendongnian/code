    public class Hash1 
        {
    
            private EventHandler myHomeMadeDelegate;
            public event EventHandler FancyEvent
            {
                add
                {
                    //myDelegate += value;
                    myHomeMadeDelegate = (EventHandler)Delegate.Combine(myHomeMadeDelegate, value);
                }
                remove
                {
                    //myDelegate -= value;
                    myHomeMadeDelegate = (EventHandler)Delegate.Remove(myHomeMadeDelegate, value);
                }
            }
            public event EventHandler PlainEvent;
            
    
            public Hash1()
            {
                FancyEvent += new EventHandler(On_Hash1_FancyEvent);
                PlainEvent += new EventHandler(On_Hash1_PlainEvent);
    
                // FancyEvent(this, EventArgs.Empty);  //won't work:What is the backing delegate called? I don't know
                myHomeMadeDelegate(this, EventArgs.Empty); // Aha!
                PlainEvent(this, EventArgs.Empty);
            }
    
            void On_Hash1_PlainEvent(object sender, EventArgs e)
            {
                Console.WriteLine("Bang Bang!");
            }
    
            void On_Hash1_FancyEvent(object sender, EventArgs e)
            {
                Console.WriteLine("Bang!");
            }
    }
