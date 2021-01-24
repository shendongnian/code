    public class CategoriesViewModel : WszystkieViewModel<CategoryAddValue>
        {
            #region Fields & Properties
            private ObservableCollection<CategoryAddValue> _listCategoryAddValue;
            public ObservableCollection<CategoryAddValue> listCategoryAddValue
            {
                get
                {
                    if (_listCategoryAddValue == null) { Load(); }
                    return _listCategoryAddValue;
                }
                set
                {
                    if (_listCategoryAddValue != value)
                    {
                        _listCategoryAddValue = value;
                        OnPropertyChanged(() => listCategoryAddValue);
                    }
                }
            }
            #endregion Fields & Properties
    
            #region Constructor
            public CategoriesViewModel() : base()
            {
                base.DisplayName = "Kategorie";
            }
            #endregion Constructor
    
            #region Helpers
            private void SendValue(int CategoryId)
            {
                Messenger.Default.Send(CategoryValueCode.AddValue + "," + CategoryId);
            }
    
            public override void Load()
            {
                var allCategories = (from k in db.Category select k).ToList();
                _listCategoryAddValue = new ObservableCollection<CategoryAddValue>();
    
                foreach (var i in allCategories)
                {
                    _listCategoryAddValue.Add(new CategoryAddValue(new RelayCommand(() => SendValue(i.KategoriaId)))
                    {
                        Category = i,
                        ValueList = db.CategoryValue.Where(x => x.CategoryId== i.CategoryId).Select(x => x.Value).ToList()
                    });
                }
            }
            #endregion Helpers
        }
