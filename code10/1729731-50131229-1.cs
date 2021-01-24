        private IDoSomething selectedVM;
        public IDoSomething SelectedVM
        {
            get { return selectedVM; }
            set
            {
                selectedVM = value;
                selectedVM.doit();
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<IDoSomething> vms { get; set; } = new ObservableCollection<IDoSomething>
        {   new uc1vm(),
            new uc2vm()
        };
        public MainWIndowViewModel()
        {
        }
