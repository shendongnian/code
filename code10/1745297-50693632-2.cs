    public class Child2ViewModel
    {
        public string Name { get; set; }
        public Child2ViewModel()
        {
            Utility.EventAggregator.GetEvent<UpdateNameEvent>().Subscribe(UpdateName);
        }
        private void UpdateName(string name)
        {
            this.Name = name;
        }
    }
