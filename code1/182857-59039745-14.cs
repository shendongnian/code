    public partial class DlgAddSignalResult : Window
    {
    	readonly WindowWithAutoBusyState _autoBusyState = new WindowWithAutoBusyState();
    
    	// ******************************************************************
    	public DlgAddSignalResult()
        {
            InitializeComponent();
    
    		Model = DataContext as DlgAddSignalResultModel;
    
    		_autoBusyState.Init(this);
    	}
