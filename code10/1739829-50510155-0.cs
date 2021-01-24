    public class PublisherClass
    {
        public void UpdateName(string name)
        {
            Utility.EventAggregator.GetEvent<UpdateNameEvent>().Publish(name);
        }
    }
