    public partial class Shell : Window, IShellView
    {
        private readonly IFormalLogger _logger;
        private readonly ILoggerFacade _loggerFacade;
 
        public Shell( IFormalLogger logger, ILoggerFacade loggerFacade )
        {
            _logger = logger;
            _loggerFacade = loggerFacade
            
            _logger.Debug( "Shell: Instantiating the .ctor." );
            _loggerFacade.Log( "My Message", Category.Debug, Priority.None );
    
            InitializeComponent();
        }
    
    
        #region IShellView Members
    
        public void ShowView()
        {
            _logger.Debug( "Shell: Showing the Shell (ShowView)." );
             _loggerFacade.Log( "Shell: Showing the Shell (ShowView).", Category.Debug, Priority.None );
           this.Show();
        }
    
        #endregion
    
    }
