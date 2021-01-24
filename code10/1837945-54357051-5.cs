    public partial class ViewA : UserControl
    {
        ILoggerFacade logger;
        public ViewA(ILoggerFacade _logger)
        {
            InitializeComponent();
            logger = _logger;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var val = 0;
                var result = 1500 / val;
            }
            catch (Exception ex)
            {
                LoggerExtensions.Warn(logger, ex.Message);
            }
       
        }
    }
