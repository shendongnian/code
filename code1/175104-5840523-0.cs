        public static event EventHandler<MyEventArgs> ServiceCallComplete;
        public static void InvokeMyAcionComplete(MyEventArgs e)
        {
            EventHandler<MyEventArgs> handler = ServiceCallComplete;
            if (handler != null) handler(null, e);
        }
        public static void CallService ()
        {
            //Performed async call  
            // Fire the event to notify listeners
            OnServiceCalled();
        }
        private static void OnServiceCalled ()
        {
            
            InvokeMyAcionComplete(new MyEventArgs());
        }
       
    }
    public class  ClientCode
    {
           public void CallService()
           {
               Communication.CallService();
               //Subscribe to the event and get notified when the call is complete
               Communication.ServiceCallComplete += OnServiceCalled;
           }
        private void OnServiceCalled(object sender, MyEventArgs e)
        {
                //MyEventArgs is your customized event argument
                //Do something with the result  
        }
    }
