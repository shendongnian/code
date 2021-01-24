    public class ViewModel : ViewModelBase
    {
        public ViewModel(object instance)
        {
            foreach (var field in instance.GetType().GetFields())
            {
                Fields.Add(new FieldViewModel(instance, field));
            }
        }
        private ObservableCollection<FieldViewModel> _fields = new ObservableCollection<FieldViewModel>();
        public ObservableCollection<FieldViewModel> Fields
        {
            get { return _fields; }
            set
            {
                _fields = value;
                OnPropertyChanged();
            }
        }
    }
