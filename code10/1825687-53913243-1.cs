    class JobEditorDetailViewModel : DialogViewModelBase
    {
        public Job Job { get; set; }
        private RelayCommand<object> _saveCommand = null;
        public RelayCommand<object> SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }
        private RelayCommand<object> _cancelCommand = null;
        public RelayCommand<object> CancelCommand
        {
            get { return _cancelCommand; }
            set { _cancelCommand = value; }
        }
        private IList<SubordinateItem> _subordinateItems = new List<SubordinateItem>();
        public IList<SubordinateItem> SubordinateItems
        {
            get { return _subordinateItems; }
            set
            {
                Set(ref _subordinateItems, value);
            }
        }
        public JobEditorDetailViewModel(string message, Job job) : base(message)
        {
            this.Job = job;
            this._saveCommand = new RelayCommand<object>((parent) => OnSaveClicked(parent));
            this._cancelCommand = new RelayCommand<object>((parent) => OnCancelClicked(parent));
            foreach (String subordinate in Job.Subordinates)
            {
                _subordinateItems.Add(new SubordinateItem(subordinate));
            }
        }
        private void OnSaveClicked(object parameter)
        {
            this.Job.Subordinates.Clear();
            foreach (SubordinateItem item in _subordinateItems)
            {
                this.Job.Subordinates.Add(item.Value);
            }
            this.CloseDialogWithResult(parameter as Window, DialogResult.Yes);
        }
        private void OnCancelClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.No);
        }
    }
