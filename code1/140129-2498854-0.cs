    public class User
    {
        public Subscription Subscription { get; set; }
        public void HandleSubscription()
        {
            Subscription.Method();
        }
    }
    
    public abstract class SubscriptionType
    {
      public abstract void Method();
    }
    
    public class NoSubscription : SubscriptionType
    {
      public override void Method()
      {
        // Do stuff for non subscribers
      }
    }
    
    public class ServiceSubscription : SubscriptionType
    {
      public override void Method()
      {
        // Do stuff for service subscribers
      }
    }
    
    public class Service2Subscription : SubscriptionType
    {
      public override void Method()
      {
        // Do stuff for service2 subscribers
      }
    }
