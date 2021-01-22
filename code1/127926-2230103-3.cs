    public class CustomerSetupControl : UserControl
    {
        public CustomerSetupControl()
        {
            InitializeComponent();
            InitializeChangeTriggers();
        }
        private void InitializeChangeTriggers()
        {
            IEventService service = IoC.Resolve<IEventService>();
            txtAccountNumber.TextChanged += service.RaiseChanged;
            txtName.TextChanged += service.RaiseChanged;
            chkIsVip.CheckedChanged += service.RaiseChanged;
            // etc.
        }
    }
