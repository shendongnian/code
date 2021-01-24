        public ObservableCollection<Family> Families { get; set; }
        public MainWindowViewModel()
        { 
        Families = new ObservableCollection<Family>();
        Family family1 = new Family() { Name = "The Doe's" };
        family1.Members.Add(new FamilyMember() { Name = "John Doe", Age = 42 });
                        family1.Members.Add(new FamilyMember() { Name = "Jane Doe", Age = 39 });
                        family1.Members.Add(new FamilyMember() { Name = "Sammy Doe", Age = 13 });
                        Families.Add(family1);
                        Family family2 = new Family() { Name = "The Moe's" };
        family2.Members.Add(new FamilyMember() { Name = "Mark Moe", Age = 31 });
                        family2.Members.Add(new FamilyMember() { Name = "Norma Moe", Age = 28 });
                        Families.Add(family2);
        }
    }
    public class Family :baseVM
    {
        public Family()
        {
            this.Members = new ObservableCollection<FamilyMember>();
        }
        public string Name { get; set; }
        public ObservableCollection<FamilyMember> Members { get; set; }
        private bool _isExpanded;
        public bool Expanded
        {
            get { return _isExpanded; }
            set
            {
                throw new Exception("Set to: " + value);
                _isExpanded = value;
                // Call OnPropertyChanged whenever the property is updated
                NotifyPropertyChanged("Expanded");
            }
        }
    }
    public class FamilyMember : baseVM
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private bool _isExpanded;
        public bool Expanded
        {
            get { return _isExpanded; }
            set
            {
                throw new Exception("Set to: " + value);
                _isExpanded = value;
                // Call OnPropertyChanged whenever the property is updated
                NotifyPropertyChanged("Expanded");
            }
        }
    }
    public class baseVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
