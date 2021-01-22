    // 'Event' type:
    delegate void DelMyEvent();
    // consumer:
    class Consumer
    {
        Producer _theProducer;
        void RegisterForNotification()
        {
           _theProducer.OnMyEvent = new DelMyEvent(OnMyEvent);
        }
        void OnMyEvent() { }
    }
    // producer:
    class Producer
    {
       public DelMyEvent OnMyEvent;
       void SendNotification()
       {
          if( OnMyEvent != null ) OnMyEvent();
       }
    }
