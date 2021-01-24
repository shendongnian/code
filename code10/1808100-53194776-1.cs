    public class Subscriber: BaseSubscriber
    {
        public override void OnEnable()
        {
            // Do smth here
            base.OnEnable();
        }
    
        public override void OnDisable()
        {
            // Do smth here
            base.OnDisable();
        }
    
        protected override void OnPublisherClicked()
        {
            Debug.Log("EventTriggered");
        }
    }
