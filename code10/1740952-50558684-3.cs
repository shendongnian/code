    public class EditRulesViewModel:ViewModelBase
    {
        
        public ObservableCollection<RuleMainSystem> RuleMainSystems { get; set; }
        private RuleMainSystem _MySelectedItem;
        public RuleMainSystem MySelectedItem
        {
            get { return _MySelectedItem; }
            set
            {
                _MySelectedItem = value;
                RuleSubSystems = MySelectedItem.RuleSubSystems;
                SubSelectedItem = MySelectedItem.RuleSubSystems.FirstOrDefault();
                RaisePropertyChanged("MySelectedItem");
            }
        }
        private ObservableCollection<RuleSubSystem> _RuleSubSystems;
        public ObservableCollection<RuleSubSystem> RuleSubSystems
        {
            get { return _RuleSubSystems; }
            set
            {
                _RuleSubSystems = value;
                RaisePropertyChanged("RuleSubSystems");
            }
        }
        
        private RuleSubSystem _SubSelectedItem;
        public RuleSubSystem SubSelectedItem
        {
            get { return _SubSelectedItem; }
            set
            {
                _SubSelectedItem = value;
                RaisePropertyChanged("SubSelectedItem");
            }
        }
        public EditRulesViewModel()
        {
            RuleMainSystems = new ObservableCollection<RuleMainSystem>();
            ObservableCollection<RuleSubSystem> SubSystems = new ObservableCollection<RuleSubSystem>();
            SubSystems.Add(new RuleSubSystem() {Name="Sub1" });
            SubSystems.Add(new RuleSubSystem() {Name="Sub2" });
            ObservableCollection<RuleSubSystem> SubSystems1 = new ObservableCollection<RuleSubSystem>();
            SubSystems1.Add(new RuleSubSystem() { Name = "Sub3" });
            SubSystems1.Add(new RuleSubSystem() { Name = "Sub4" });
            RuleMainSystems.Add(new RuleMainSystem() {Name="Rule1",RuleSubSystems = SubSystems });
            RuleMainSystems.Add(new RuleMainSystem() { Name = "Rule2", RuleSubSystems = SubSystems1 });
            MySelectedItem = RuleMainSystems.FirstOrDefault();
        }
    }
