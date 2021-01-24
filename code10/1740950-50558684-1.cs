    public class RuleMainSystem
    {
        public string Name { get; set; }
        // Some more single properties...
        public ObservableCollection<RuleSubSystem> RuleSubSystems { get; set; }
    }
    public class RuleSubSystem
    {
        public string Name { get; set; }
        // Some more single properties...
    }
