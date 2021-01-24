    public class SubscriberClass2
    {
        public string Name { get; set; }
        public SubscriberClass2()
        {
            Utility.EventAggregator.GetEvent<UpdateNameEvent>().Subscribe(UpdateName);
        }
        private void UpdateName(string name)
        {
            this.Name = name;
        }
    }
