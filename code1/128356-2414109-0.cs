            eventsSubscriptions["1"].EventHandler = new EventHandler(this.Method1);
            eventsSubscriptions["2"].EventHandler = new EventHandler(this.Method2);
            eventsSubscriptions["3"].EventHandler = new EventHandler(this.Method3);
            Boss Boss1 = new Boss("John Smith");
            Boss Boss2 = new Boss("Cynthia Jameson");
            Employed Employed1  = new Employed("David Ryle");
            Employed Employed2 = new Employed("Samantha Sun");
            Employed Employed3 = new Employed("Dick Banshee");
         
            // Subscribe objects to Method 1
            eventsSubscriptions["1"].Subscribe(Boss1);
            eventsSubscriptions["1"].Subscribe(Employed1);
            // Subscribe objects to Method 2
            eventsSubscriptions["2"].Subscribe(Boss2);
            eventsSubscriptions["2"].Subscribe(Employed2);
            
            // Subscribe objects to Method 3
            eventsSubscriptions["3"].Subscribe(Employed3);
