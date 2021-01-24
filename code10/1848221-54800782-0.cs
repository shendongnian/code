    [assembly: Dependency(typeof(SendNotifiImplementation))]
    namespace xxx.iOS
    {
      public class SendNotifiImplementation: ISendNotifi
      {
        public SendNotifiImplementation() { }
    
        void SendNotifi(string content)
        {
            // send notification
        }
      }
    }
