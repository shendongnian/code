    public class Child1ViewModel
    {
        public string Name { get; set; }
        public Child1ViewModel()
        {
            Utility.EventAggregator.GetEvent<UpdateNameEvent>().Subscribe(UpdateName);
        }
        private void UpdateName(string name)
        {
            this.Name = name;
        }
    }
