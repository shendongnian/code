       class MainWindowVM : BindableBase
    {
        private string m_bindableTextProperty;
        public MainWindowVM() 
        {
            DoAction = new DelegateCommand(ExecuteDoAction,CanExecuteDoAction); 
        }
        public string BindableTextProperty
        {
            get { return m_bindableTextProperty; }
            set { SetProperty(ref m_bindableTextProperty , value); }
        }
        public DelegateCommand DoAction
        {
            get;
            private set;
        }
        private bool CanExecuteDoAction()
        {
            return true;
        }
        private void ExecuteDoAction() 
        { 
          // Do something
          // You could enter the Folder selection code here 
            BindableTextProperty = "Done"; 
        }
    }
