    public class TreeViewItemViewModel : BindableBase
        {
    
            private string _name;
            private TreeViewItemViewModel _parent;
            private List<TreeViewItemViewModel> _childern;
            
    
            public TreeViewItemViewModel(TreeViewItemViewModel parent, string name)
            {
                _parent = parent;
                _name = name;
    
                _childern = new List<TreeViewItemViewModel>();
            }
    
    
    
            public string Name
            {
                get
                {
                    return _name;
                }
            }
    
            public TreeViewItemViewModel Parent
            {
                get
                {
                    return _parent;
                }
            }
    
            public List<TreeViewItemViewModel> Children
            {
                get
                {
                    return _childern;
                }
            }
    
            public void AddChild(TreeViewItemViewModel c)
            {
                _childern.Add(c);
                RaisePropertyChanged(nameof(Children));
            }
         
        }
