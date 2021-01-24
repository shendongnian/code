    public class SubscriberClass1
    {
        public string Name { get; set; }
        public SubscriberClass1()
        {
            Utility.EventAggregator.GetEvent<UpdateNameEvent>().Subscribe(UpdateName);
        }
        private void UpdateName(string name)
        {
            this.Name = name;
        }
    }
