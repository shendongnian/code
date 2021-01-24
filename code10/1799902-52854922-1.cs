    public class ViewModel
    {
        private List<SecondViewModel> _secondViewModels = new List<SecondViewModel>();
        public IEnumerable<SecondViewModel> SecondViewModels => _secondViewModels;
        public int myProperty => _secondViewModels.Sum(vm => vm.SecondProperty);
        public void AddSecondViewModel(SecondViewModel vm)
        {
            _secondViewModels.Add(vm);
            vm.PropertyChanged += (s,e) => OnPropertyChanged("myProperty");
            OnPropertyChanged("myProperty");
        }
    }
