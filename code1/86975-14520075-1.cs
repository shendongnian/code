    public class MenuItemViewModel : BaseViewModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
            /// </summary>
            /// <param name="parentViewModel">The parent view model.</param>
            public MenuItemViewModel(MenuItemViewModel parentViewModel)
            {
                ParentViewModel = parentViewModel;
                _childMenuItems = new ObservableCollection<MenuItemViewModel>();
            }
    
            private ObservableCollection<MenuItemViewModel> _childMenuItems;
            /// <summary>
            /// Gets the child menu items.
            /// </summary>
            /// <value>The child menu items.</value>
            public ObservableCollection<MenuItemViewModel> ChildMenuItems
            {
                get
                {
                    return _childMenuItems;
                }
            }
    
            private string _header;
            /// <summary>
            /// Gets or sets the header.
            /// </summary>
            /// <value>The header.</value>
            public string Header
            {
                get
                {
                    return _header;
                }
                set
                {
                    _header = value; NotifyOnPropertyChanged("Header");
                }
            }
    
            /// <summary>
            /// Gets or sets the parent view model.
            /// </summary>
            /// <value>The parent view model.</value>
            public MenuItemViewModel ParentViewModel { get; set; }
    
            public virtual void LoadChildMenuItems()
            {
                
            }
        }
