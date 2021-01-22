    public class DummyViewModel : ViewModelBase
    {
        private class DummyViewModelPropertyInfo
        {
            internal readonly string Dummy;
            internal DummyViewModelPropertyInfo(DummyViewModel model)
            {
                Dummy = BindingHelper.Name(() => model.Dummy);
            }
        }
        private static DummyViewModelPropertyInfo _propertyInfo;
        private DummyViewModelPropertyInfo PropertyInfo
        {
            get { return _propertyInfo ?? (_propertyInfo = new DummyViewModelPropertyInfo(this)); }
        }
        private string _dummyProperty;
        public string Dummy
        {
            get
            {
                return this._dummyProperty;
            }
            set
            {
                this._dummyProperty = value;
                OnPropertyChanged(PropertyInfo.Dummy);
            }
        }
    }
