     public class MyInstanceContextInitializer : IInstanceContextInitializer
      {
        public void Initialize(InstanceContext instanceContext, Message message)
        {
          // hook up to events to get notified about changes in the state of this instance context.
          // remember refernce to it
        }
      }
