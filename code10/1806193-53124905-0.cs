    public class TreeData : BindableBase
    {
        private bool _isExpanded = false;
        private bool _isSelected = false;
        private bool _hasChildren = false;
        private Func<List<TreeData>> _getChildrenMethod;
        private bool _isLoaded = false;
        public TreeData(string value, bool hasChildren, Func<List<TreeData>> getChildren)
        {
            Value = value;
            _hasChildren = hasChildren;
            _getChildrenMethod = getChildren;
            if(hasChildren)
            {
                Children.Add(new TreeNode("Dummy", false, null));
            }
        }
        public ObservableCollection<TreeData> Children { get; set; } = new ObservableCollection<TreeData>();
        public string Value {get;set;}
        public bool IsSelected
        {
           get { return _isSelected; }
           set { _isSelected = value; OnPropertyChanged(); }
        }
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                 _isExpanded = value;
                 if(!_isLoaded)
                 {
                     // Call load method here
                     if(_addChildrenMethod != null && _hasChildren)
                     {
                         Children.Clear();
                         Children.AddMany(_addChildrenMethod());
                     }
                     _isLoaded = true;
                 }
                 OnPropertyChanged();
            }
        }
    }
