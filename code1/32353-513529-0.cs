    public partial class Main : Form
    {
        private static Main mainFormForLogging;
        public static Main MainFormForLogging
        {
            get
            {
                return mainFormForLogging;
            }
        }
    
        public Main()
        {
            InitializeComponent();
    
            if (mainFormForLogging == null)
            {
                mainFormForLogging = this;
            }
        }
    
        protected void Dispose(bool disposing)
        {
             if (disposing)
             {
                 if (this == mainFormForLogging)
                 {
                    mainFormForLogging = null;
                 }
             }
    
             base.Dispose(disposing);
        }
    }
