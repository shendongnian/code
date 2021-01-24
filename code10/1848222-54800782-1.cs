    [assembly: Dependency(typeof(SendNotifiImplementation))]
    namespace xxx.Droid
    {
      public class SendNotifiImplementation: ISendNotifi
      {
        public SendNotifiImplementation(Context context):base(context) { }
        void SendNotifi(string content)
        {
            // send notification
        }
      }
    }
