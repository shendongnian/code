    public Form1()
        {
            SimpleEventSender newevent1 = new SimpleEventSender();
 
            // You are subscribing to the event of this instance            
            newevent1.NewEvent += new_event;
            InitializeComponent();
        }
-
        public static void CountStart()
        {
    
            int CountVal = 0;
            do
            {
                CountVal = CountVal + 1;
                if (CountVal % 5 == 0)
                {
                    // But here you are creating another instance of SimpleEventSender so it doesn't have anything subscribed to it
                    SimpleEventSender EventSender = new SimpleEventSender();
                    EventSender.StartEvent();
                }
                Thread.Sleep(1000);
            } while (CountVal < 100);
        }
    
