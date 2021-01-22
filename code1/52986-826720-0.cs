    public class QueueViewModel : INotifyPropertyChanged
    {
        public ParentType Parent { get; set; }
    
        public QueueViewModel(ParentType parent)
        {
            this.Parent = parent;
            foreach (ChildType child in Parent)
            {
                child.PropertyChanged += delegate(object sender,
                    PropertyChangedEventArgs e)
                {
                    if (e.PropertyName != "IsSelected")
                        return;
    
                    //do something like this:
                    Parent.IsSelected = AllChildrenAreSelected();
                };
            }
        }
    
    }
    
    public class ParentType : INotifyPropertyChanged
    {
        private bool _isSelected;
    
        public IList<ChildType> Children { get; set; }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }
    
    public class ChildType : INotifyPropertyChanged
    {
        private string _name;
        private bool _isSelected;
    
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
    
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }
