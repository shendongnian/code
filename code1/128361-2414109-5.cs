    namespace MyExample
    {
        public class SomeExampleClass
        {
    
            private EventsSubscriptions eventsSubscriptions = new EventsSubscriptions();
    
            private void Method1(object sender, System.EventArgs e)
            {
                Console.WriteLine("Method 1 raised with " + sender.ToString());
            }
    
            private void Method2(object sender, System.EventArgs e)
            {
                Console.WriteLine("Method 2 raised with " + sender.ToString());
            }
    
            private void Method3(object sender, System.EventArgs e)
            {
                Console.WriteLine("Method 3 raised with " + sender.ToString());
            }
    
            public void SuscribeObjects()
            {            
                eventsSubscriptions["1"].EventHandler = new EventHandler(this.Method1);
                eventsSubscriptions["2"].EventHandler = new EventHandler(this.Method2);
                eventsSubscriptions["3"].EventHandler = new EventHandler(this.Method3);
    
                Boss Boss1 = new Boss("John Smith");
                Boss Boss2 = new Boss("Cynthia Jameson");
    
                Employee Employee1  = new Employee("David Ryle");
                Employee Employee2 = new Employee("Samantha Sun");
                Employee Employee3 = new Employee("Dick Banshee");
             
                // Method 1
                eventsSubscriptions["1"].Subscribe(Boss1);
                eventsSubscriptions["1"].Subscribe(Employee1);
    
                //// Method 2
                eventsSubscriptions["2"].Subscribe(Boss2);
                eventsSubscriptions["2"].Subscribe(Employee2);
                
                //// Method 3
                eventsSubscriptions["3"].Subscribe(Employee3);
    
            }
    
            public void RaiseAllEvents()
            {
                eventsSubscriptions.RaiseAllEvents();
            }
    
        }
    }
