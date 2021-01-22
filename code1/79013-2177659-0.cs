    public class BasketModelView
    {
        private readonly Lazy<ObservableCollection<AppleModelView>> _appleViews;
        public BasketModelView(BasketModel basket)
        {
            Func<AppleModel, AppleModelView> viewModelCreator = model => new AppleModelView(model);
            Func<ObservableCollection<AppleModelView>> collectionCreator =
                () => new ObservableViewModelCollection<AppleModelView, AppleModel>(basket.Apples, viewModelCreator);
            _appleViews = new Lazy<ObservableCollection<AppleModelView>>(collectionCreator);
        }
        public ObservableCollection<AppleModelView> Apples
        {
            get
            {
                return _appleViews.Value;
            }
        }
    }
