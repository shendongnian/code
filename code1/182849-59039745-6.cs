       public partial class DlgAddSignalResult : Window
        {
    		readonly WindowWithAutoBusyState _overrideCursorMtForWindow = new WindowWithAutoBusyState();
    
    		// ******************************************************************
    		public DlgAddSignalResult()
            {
                InitializeComponent();
    
                this.IsVisibleChanged += DlgAddSignalResultIsVisibleChanged;
